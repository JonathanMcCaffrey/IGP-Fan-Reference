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
    private BuildOrderModel buildOrder = new();
    public int BuildingInputDelay { get; set; } = 2;
    private int lastInterval = 0;

    public BuildOrderService()
    {
        Reset();
    }

    public Dictionary<int, List<EntityModel>> StartedOrders => buildOrder.StartedOrders;
    public Dictionary<int, List<EntityModel>> CompletedOrders => buildOrder.CompletedOrders;
    public Dictionary<string, int> UniqueCompletedTimes => buildOrder.UniqueCompletedTimes;
    public Dictionary<int, int> SupplyCountTimes => buildOrder.SupplyCountTimes;

    public int GetLastRequestInterval()
    {
        return lastInterval;
    }

    public Dictionary<int, List<EntityModel>> GetOrders()
    {
        return buildOrder.StartedOrders;
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
        if (!buildOrder.StartedOrders.ContainsKey(atInterval))
            buildOrder.StartedOrders.Add(atInterval, new List<EntityModel>());

        var production = entity.Production();

        var completedTime = atInterval;
        if (production != null) completedTime += production.BuildTime;

        if (!buildOrder.CompletedOrders.ContainsKey(completedTime))
            buildOrder.CompletedOrders.Add(completedTime, new List<EntityModel>());

        var supply = entity.Supply();


        buildOrder.StartedOrders[atInterval].Add(entity.Clone());
        buildOrder.CompletedOrders[completedTime].Add(entity.Clone());

        if (!buildOrder.UniqueCompletedTimes.ContainsKey(entity.DataType))
            buildOrder.UniqueCompletedTimes.Add(entity.DataType, atInterval);

        if (!buildOrder.UniqueCompletedCount.ContainsKey(entity.DataType))
            buildOrder.UniqueCompletedCount.Add(entity.DataType, 1);
        else
            buildOrder.UniqueCompletedCount[entity.DataType]++;

        if (supply != null)
        {
            if (!supply.Takes.Equals(0)) buildOrder.CurrentSupplyUsed += supply.Takes;
            if (!supply.Grants.Equals(0))
                buildOrder.SupplyCountTimes.Add(buildOrder.SupplyCountTimes.Last().Key + supply.Grants, completedTime);
        }


        if (atInterval > lastInterval) lastInterval = atInterval;

        NotifyDataChanged();
    }


    public int? WillMeetRequirements(EntityModel entity)
    {
        var requirements = entity.Requirements();

        if (requirements.Count == 0) return 0;

        var metTime = 0;
        foreach (var requiredEntity in requirements)
            if (buildOrder.UniqueCompletedTimes.TryGetValue(requiredEntity.Id, out var completedTime))
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

        foreach (var supplyAtTime in buildOrder.SupplyCountTimes)
            if (supply.Takes + buildOrder.CurrentSupplyUsed < supplyAtTime.Key)
                return supplyAtTime.Value;

        return null;
    }


    public bool Add(EntityModel entity, IEconomyService withEconomy, IToastService withToasts)
    {
        var atInterval = lastInterval;

        if (!HandleSupply(entity, withToasts, ref atInterval)) return false;
        if (!HandleRequirements(entity, withToasts, ref atInterval)) return false;
        if (!HandleEconomy(entity, withEconomy, withToasts, ref atInterval)) return false;

        Add(entity, atInterval);

        return true;
    }

    public void RemoveLast()
    {
        if (buildOrder.StartedOrders.Keys.Count > 1)
        {
            var lastStarted = buildOrder.StartedOrders.Keys.Last();
            var lastCompleted = buildOrder.CompletedOrders.Keys.Last();

            EntityModel entityRemoved = default!;

            if (buildOrder.StartedOrders[lastStarted].Count > 0)
            {
                entityRemoved = buildOrder.StartedOrders[lastStarted].Last();
                buildOrder.StartedOrders[lastStarted].Remove(buildOrder.StartedOrders[lastStarted].Last());
                buildOrder.CompletedOrders[lastCompleted].Remove(buildOrder.CompletedOrders[lastCompleted].Last());
            }

            if (buildOrder.StartedOrders[lastStarted].Count == 0) buildOrder.StartedOrders.Remove(lastStarted);
            if (buildOrder.CompletedOrders[lastCompleted].Count == 0) buildOrder.CompletedOrders.Remove(lastCompleted);

            if (buildOrder.StartedOrders.Keys.Count > 0)
                lastInterval = buildOrder.StartedOrders.Keys.Last();
            else
                lastInterval = 0;

            if (entityRemoved.Supply()?.Grants > 0)
                SupplyCountTimes.Remove(SupplyCountTimes.Last().Key);

            if (entityRemoved.Supply()?.Takes > 0)
                buildOrder.CurrentSupplyUsed -= entityRemoved.Supply()!.Takes;


            buildOrder.UniqueCompletedCount[entityRemoved!.DataType]--;
            if (buildOrder.UniqueCompletedCount[entityRemoved!.DataType] == 0)
                UniqueCompletedTimes.Remove(entityRemoved.DataType);

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
        return JsonSerializer.Serialize(buildOrder, options);
    }

    public string BuildOrderAsYaml()
    {
        var stringBuilder = new StringBuilder();
        var serializer = new Serializer();
        stringBuilder.AppendLine(serializer.Serialize(buildOrder));
        var buildOrderText = stringBuilder.ToString();
        return buildOrderText;
    }


    public List<EntityModel> GetCompletedBefore(int interval)
    {
        return (from ordersAtTime in buildOrder.StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            select orders).ToList();
    }

    public List<EntityModel> GetHarvestersCompletedBefore(int interval)
    {
        return (from ordersAtTime in buildOrder.StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            where orders.Harvest() != null
            select orders).ToList();
    }


    public void SetName(string name)
    {
        buildOrder.Name = name;
        NotifyDataChanged();
    }

    public string GetName()
    {
        return buildOrder.Name;
    }

    public void SetNotes(string notes)
    {
        buildOrder.Notes = notes;
        NotifyDataChanged();
    }

    public string GetNotes()
    {
        return buildOrder.Notes;
    }

    public void SetColor(string color)
    {
        buildOrder.Color = color;
        NotifyDataChanged();
    }

    public string GetColor()
    {
        return buildOrder.Color;
    }

    public void Reset()
    {
        lastInterval = 0;
        
        buildOrder = new BuildOrderModel
        {
            StartedOrders = new Dictionary<int, List<EntityModel>>
            {
                {
                    0,
                    new List<EntityModel>
                    {
                        EntityModel.Get(DataType.STARTING_Bastion),
                        EntityModel.Get(DataType.STARTING_TownHall_Aru)
                    }
                }
            },
            CompletedOrders = new Dictionary<int, List<EntityModel>>
            {
                {
                    0,
                    new List<EntityModel>
                    {
                        EntityModel.Get(DataType.STARTING_Bastion),
                        EntityModel.Get(DataType.STARTING_TownHall_Aru)
                    }
                }
            },
            UniqueCompletedTimes = new Dictionary<string, int>
            {
                {
                    DataType.STARTING_Bastion, 0
                },
                {
                    DataType.STARTING_TownHall_Aru, 0
                }
            },
            UniqueCompletedCount = new Dictionary<string, int>
            {
                {
                    DataType.STARTING_Bastion, 1
                },
                {
                    DataType.STARTING_TownHall_Aru, 1
                }
            },
            SupplyCountTimes = new Dictionary<int, int>
            {
                {
                    0, 0
                }
            }
        };
        
        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private bool HandleEconomy(EntityModel entity, IEconomyService withEconomy, IToastService withToasts,
        ref int atInterval)
    {
        var production = entity.Production();

        if (production == null) return true;

        for (var interval = atInterval; interval < withEconomy.GetOverTime().Count; interval++)
        {
            var economyAtSecond = withEconomy.GetOverTime()[interval];
            if (economyAtSecond.Alloy >= production.Alloy && economyAtSecond.Ether >= production.Ether &&
                economyAtSecond.Pyre >= production.Pyre)
            {
                atInterval = interval;

                if (entity.EntityType != EntityType.Army) atInterval += BuildingInputDelay;
                
                return true;
            }
        }

        if (withEconomy.GetOverTime().Last().Ether < production.Ether)
            withToasts.AddToast(new ToastModel
            {
                Title = "Not Enough Ether", Message = "Build more ether extractors!",
                SeverityType = SeverityType.Error
            });

        if (withEconomy.GetOverTime().Last().Alloy < production.Alloy)
            withToasts.AddToast(new ToastModel
            {
                Title = "Not Enough Alloy", Message = "Build more bases!",
                SeverityType = SeverityType.Error
            });

        return false;
    }

    private bool HandleSupply(EntityModel entity, IToastService withToasts, ref int atInterval)
    {
        var minSupplyInterval = WillMeetSupply(entity);
        if (minSupplyInterval == null)
        {
            withToasts.AddToast(new ToastModel
            {
                Title = "Supply Cap Reached", Message = "Build more supply!",
                SeverityType = SeverityType.Error
            });

            return false;
        }

        if (minSupplyInterval > atInterval) atInterval = (int)minSupplyInterval;

        return true;
    }

    private bool HandleRequirements(EntityModel entity, IToastService withToasts, ref int atInterval)
    {
        var minRequirementInterval = WillMeetRequirements(entity);
        if (minRequirementInterval == null)
        {
            withToasts.AddToast(new ToastModel
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