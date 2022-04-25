using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.BuildOrders;
using Model.Entity;
using Model.Entity.Data;
using Model.Feedback;
using Model.Types;
using YamlDotNet.Serialization;

namespace Services.Immortal;

public class BuildOrderService : IBuildOrderService
{
    private readonly BuildOrderModel _buildOrder = new();

    private readonly ITimingService _timingService;

    private readonly IToastService _toastService;

    private int _lastInterval;

    public BuildOrderService(IToastService toastService, ITimingService timingService)
    {
        _toastService = toastService;
        _timingService = timingService;

        Reset();
    }

    public Dictionary<int, List<EntityModel>> StartedOrders => _buildOrder.StartedOrders;
    public Dictionary<int, List<EntityModel>> CompletedOrders => _buildOrder.CompletedOrders;
    public Dictionary<string, int> UniqueCompletedTimes => _buildOrder.UniqueCompletedTimes;
    public Dictionary<int, int> SupplyCountTimes => _buildOrder.SupplyCountTimes;

    public int GetLastRequestInterval()
    {
        return _lastInterval;
    }

    public Dictionary<int, List<EntityModel>> GetOrders()
    {
        return _buildOrder.StartedOrders;
    }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }


    public void Add(EntityModel entity, int atInterval)
    {
        if (!_buildOrder.StartedOrders.ContainsKey(atInterval))
            _buildOrder.StartedOrders.Add(atInterval, new List<EntityModel>());

        var production = entity.Production();

        var completedTime = atInterval;
        if (production != null) completedTime += production.BuildTime;

        if (!_buildOrder.CompletedOrders.ContainsKey(completedTime))
            _buildOrder.CompletedOrders.Add(completedTime, new List<EntityModel>());

        _buildOrder.StartedOrders[atInterval].Add(entity.Clone());
        _buildOrder.CompletedOrders[completedTime].Add(entity.Clone());

        if (!_buildOrder.UniqueCompletedTimes.ContainsKey(entity.DataType))
            _buildOrder.UniqueCompletedTimes.Add(entity.DataType, atInterval);

        if (!_buildOrder.UniqueCompletedCount.ContainsKey(entity.DataType))
            _buildOrder.UniqueCompletedCount.Add(entity.DataType, 1);
        else
            _buildOrder.UniqueCompletedCount[entity.DataType]++;

        if (!_buildOrder.UniqueCompleted.ContainsKey(entity.DataType))
            _buildOrder.UniqueCompleted.Add(entity.DataType, new List<EntityModel>());

        if (entity.Production()?.ProducedBy != null)
            _buildOrder.TrainingCapacityUsed.Add(new TrainingCapacityUsedModel
            {
                StartingUsageTime = atInterval,
                StopUsageTime = completedTime,
                UsedSlots = entity.Supply() != null ? entity.Supply()!.Takes : 1,
                UsedBuilding = entity.Production()!.ProducedBy
            });

        _buildOrder.UniqueCompleted[entity.DataType].Add(entity);

        if (entity.Supply() != null && entity.Supply()!.Takes > 0)
            _buildOrder.CurrentSupplyUsed += entity.Supply()!.Takes;
        if (entity.Supply() != null && entity.Supply()!.Grants > 0)
            _buildOrder.SupplyCountTimes.Add(_buildOrder.SupplyCountTimes.Last().Key + entity.Supply()!.Grants,
                completedTime);

        if (atInterval > _lastInterval) _lastInterval = atInterval;

        NotifyDataChanged();
    }

    public bool AddWait(int forInterval)
    {
        if (forInterval < 0)
        {
            _toastService.AddToast(new ToastModel
                { SeverityType = SeverityType.Error, Title = "Wait", Message = "This should never happen." });
            return false;
        }

        _lastInterval += forInterval;

        if (!_buildOrder.StartedOrders.ContainsKey(_lastInterval))
            _buildOrder.StartedOrders.Add(_lastInterval, new List<EntityModel>());

        if (!_buildOrder.CompletedOrders.ContainsKey(_lastInterval))
            _buildOrder.CompletedOrders.Add(_lastInterval, new List<EntityModel>());

        NotifyDataChanged();
        return true;
    }

    public bool AddWaitTo(int interval)
    {
        if (interval <= _lastInterval)
        {
            _toastService.AddToast(new ToastModel
            {
                SeverityType = SeverityType.Error, Title = "Logic Error",
                Message = "You cannot wait to a time that has already elapsed."
            });
            return false;
        }

        _lastInterval = interval;

        if (!_buildOrder.StartedOrders.ContainsKey(_lastInterval))
            _buildOrder.StartedOrders.Add(_lastInterval, new List<EntityModel>());

        if (!_buildOrder.CompletedOrders.ContainsKey(_lastInterval))
            _buildOrder.CompletedOrders.Add(_lastInterval, new List<EntityModel>());

        NotifyDataChanged();
        return true;
    }

    public int? WillMeetRequirements(EntityModel entity)
    {
        var requirements = entity.Requirements();

        if (requirements.Count == 0) return 0;

        var metTime = 0;
        foreach (var requiredEntity in requirements)
            if (_buildOrder.UniqueCompletedTimes.TryGetValue(requiredEntity.Id, out var completedTime))
            {
                if (completedTime > metTime) metTime = completedTime;
            }
            else
            {
                return null;
            }

        return metTime;
    }

    public int? WillMeetSupply(EntityModel entity)
    {
        var supply = entity.Supply();

        if (supply == null || supply.Takes.Equals(0)) return 0;

        foreach (var supplyAtTime in _buildOrder.SupplyCountTimes)
            if (supply.Takes + _buildOrder.CurrentSupplyUsed <= supplyAtTime.Key)
                return supplyAtTime.Value;

        return null;
    }


    public bool Add(EntityModel entity, IEconomyService withEconomy)
    {
        var atInterval = _lastInterval;

        if (!HandleSupply(entity, ref atInterval)) return false;
        if (!HandleRequirements(entity, ref atInterval)) return false;
        if (!HandleEconomy(entity, withEconomy, ref atInterval)) return false;
        if (!HandleTrainingQueue(entity, ref atInterval)) return false;

        Add(entity, atInterval);

        return true;
    }

    public void RemoveLast()
    {
        if (_buildOrder.StartedOrders.Keys.Count > 1)
        {
            if (_buildOrder.StartedOrders.Count == 0)
            {
                _buildOrder.StartedOrders.Remove(_buildOrder.StartedOrders.Last().Key);
                _buildOrder.CompletedOrders.Remove(_buildOrder.CompletedOrders.Last().Key);

                _lastInterval = _buildOrder.StartedOrders.Last().Key;
                return;
            }

            var lastStarted = _buildOrder.StartedOrders.Keys.Last();
            var lastCompleted = _buildOrder.CompletedOrders.Keys.Last();

            EntityModel entityRemoved = default!;

            if (_buildOrder.StartedOrders[lastStarted].Count > 0)
            {
                entityRemoved = _buildOrder.StartedOrders[lastStarted].Last();
                _buildOrder.StartedOrders[lastStarted].Remove(_buildOrder.StartedOrders[lastStarted].Last());
                _buildOrder.CompletedOrders[lastCompleted].Remove(_buildOrder.CompletedOrders[lastCompleted].Last());
            }

            if (_buildOrder.StartedOrders[lastStarted].Count == 0) _buildOrder.StartedOrders.Remove(lastStarted);
            if (_buildOrder.CompletedOrders[lastCompleted].Count == 0)
                _buildOrder.CompletedOrders.Remove(lastCompleted);

            if (_buildOrder.StartedOrders.Keys.Count > 0)
                _lastInterval = _buildOrder.StartedOrders.Keys.Last();
            else
                _lastInterval = 0;

            if (entityRemoved.Supply()?.Grants > 0)
                SupplyCountTimes.Remove(SupplyCountTimes.Last().Key);

            if (entityRemoved.Supply()?.Takes > 0)
                _buildOrder.CurrentSupplyUsed -= entityRemoved.Supply()!.Takes;

            _buildOrder.UniqueCompletedCount[entityRemoved!.DataType]--;
            if (_buildOrder.UniqueCompletedCount[entityRemoved!.DataType] == 0)
                UniqueCompletedTimes.Remove(entityRemoved.DataType);

            _buildOrder.UniqueCompleted[entityRemoved.DataType]
                .Remove(_buildOrder.UniqueCompleted[entityRemoved.DataType].Last());

            if (entityRemoved.Production() != null
                && entityRemoved.Production()!.ProducedBy != null
                && entityRemoved.Supply() != null
                && entityRemoved.Supply()!.Takes > 0)
                _buildOrder.TrainingCapacityUsed.Remove(_buildOrder.TrainingCapacityUsed.Last());

            if (entityRemoved.Info().Descriptive == DescriptiveType.Worker)
            {
                RemoveLast();
                return;
            }

            NotifyDataChanged();
        }
    }


    public string AsJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Serialize(_buildOrder, options);
    }

    public string BuildOrderAsYaml()
    {
        var stringBuilder = new StringBuilder();
        var serializer = new Serializer();
        stringBuilder.AppendLine(serializer.Serialize(_buildOrder));
        var buildOrderText = stringBuilder.ToString();
        return buildOrderText;
    }


    public List<EntityModel> GetCompletedBefore(int interval)
    {
        return (from ordersAtTime in _buildOrder.StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            select orders).ToList();
    }

    public List<EntityModel> GetHarvestPointsCompletedBefore(int interval)
    {
        return (from ordersAtTime in _buildOrder.StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            where orders.Harvest() != null
            select orders).ToList();
    }


    public void SetName(string name)
    {
        _buildOrder.Name = name;
        NotifyDataChanged();
    }

    public string GetName()
    {
        return _buildOrder.Name;
    }

    public void SetNotes(string notes)
    {
        _buildOrder.Notes = notes;
        NotifyDataChanged();
    }

    public string GetNotes()
    {
        return _buildOrder.Notes;
    }

    public void DeprecatedSetColor(string color)
    {
    }

    public string GetColor()
    {
        return "";
    }

    public void Reset()
    {
        _lastInterval = 0;
        _buildOrder.Initialize(DataType.FACTION_Aru);
        NotifyDataChanged();
    }

    public int? WillMeetTrainingQueue(EntityModel entity)
    {
        var supply = entity.Supply();
        var production = entity.Production();

        var checkedInterval = _lastInterval;

        if (supply == null || production == null || supply.Takes.Equals(0))
        {
            return 1;
        }

        var producedBy = production.ProducedBy;
        if (producedBy == null)
        {
            return 1;
        }

        var uniqueCompleted = _buildOrder.UniqueCompleted[producedBy];

        var shortestIncrement = int.MaxValue;
        var trainingSlots = 0;
        var didDelay = false;

        foreach (var productionEntity in uniqueCompleted) trainingSlots += productionEntity.Supply()!.Grants;


        while (true)
        {
            var usedSlots = 0;
            foreach (var used in _buildOrder.TrainingCapacityUsed)
                if (checkedInterval >= used.StartingUsageTime && checkedInterval < used.StopUsageTime)
                {
                    usedSlots += used.UsedSlots;
                    var duration = used.StopUsageTime - used.StartingUsageTime;
                    if (duration < shortestIncrement) shortestIncrement = duration;
}

            if (usedSlots + supply.Takes <= trainingSlots)
            {
                if (didDelay)
                    _toastService.AddToast(new ToastModel
                    {
                        Title = "Waited", SeverityType = SeverityType.Information,
                        Message = $"Had to wait {checkedInterval - _lastInterval}s for Training Queue."
                    });

                return checkedInterval;
            }

            checkedInterval += shortestIncrement;
            didDelay = true;

            if (shortestIncrement == int.MaxValue)
            {
                return null;
            }
        }
    }

    private event Action OnChange = null!;

    private bool HandleEconomy(EntityModel entity, IEconomyService withEconomy, ref int atInterval)
    {
        var production = entity.Production();

        if (production == null) return true;

        for (var interval = atInterval; interval < withEconomy.GetOverTime().Count; interval++)
        {
            var economyAtSecond = withEconomy.GetOverTime()[interval];
            if (economyAtSecond.Alloy >= production.Alloy
                && economyAtSecond.Ether >= production.Ether
                && economyAtSecond.Pyre >= production.Pyre)
            {
                atInterval = interval;

                if (entity.EntityType != EntityType.Army) atInterval += _timingService.BuildingInputDelay;

                return true;
            }
        }

        if (withEconomy.GetOverTime().Last().Ether < production.Ether)
            _toastService.AddToast(new ToastModel
            {
                Title = "Not Enough Ether", Message = "Build more ether extractors!",
                SeverityType = SeverityType.Error
            });

        if (withEconomy.GetOverTime().Last().Alloy < production.Alloy)
            _toastService.AddToast(new ToastModel
            {
                Title = "Not Enough Alloy", Message = "Build more bases!",
                SeverityType = SeverityType.Error
            });

        return false;
    }

    private bool HandleSupply(EntityModel entity, ref int atInterval)
    {
        var minSupplyInterval = WillMeetSupply(entity);
        if (minSupplyInterval == null)
        {
            _toastService.AddToast(new ToastModel
            {
                Title = "Supply Cap Reached", Message = "Build more supply!",
                SeverityType = SeverityType.Error
            });

            return false;
        }

        if (minSupplyInterval > atInterval) atInterval = (int)minSupplyInterval;

        return true;
    }

    private bool HandleTrainingQueue(EntityModel entity, ref int atInterval)
    {
        var minTrainingQueueInterval = WillMeetTrainingQueue(entity);
        if (minTrainingQueueInterval == null)
        {
            _toastService.AddToast(new ToastModel
            {
                Title = "Invalid", Message = "Invalid Training Queue error",
                SeverityType = SeverityType.Error
            });

            return false;
        }

        if (minTrainingQueueInterval > atInterval) atInterval = (int)minTrainingQueueInterval;

        return true;
    }


    private bool HandleRequirements(EntityModel entity, ref int atInterval)
    {
        var minRequirementInterval = WillMeetRequirements(entity);
        if (minRequirementInterval == null)
        {
            _toastService.AddToast(new ToastModel
            {
                Title = "Missing Requirements", Message = "You don't have what's needed for this unit.",
                SeverityType = SeverityType.Error
            });

            return false;
        }

        if (minRequirementInterval > atInterval) atInterval = (int)minRequirementInterval;

        return true;
    }

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}