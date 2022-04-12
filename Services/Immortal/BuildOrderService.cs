﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.BuildOrders;
using Model.Entity;
using Model.Feedback;
using Model.Types;
using YamlDotNet.Serialization;

namespace Services.Immortal;

public class BuildOrderService : IBuildOrderService
{
    private readonly BuildOrderModel buildOrder = new();
    private readonly int HumanMicro = 2;
    private int lastInterval;

    public int GetLastRequestInterval()
    {
        return lastInterval;
    }

    public Dictionary<int, List<EntityModel>> GetOrders()
    {
        return buildOrder.Orders;
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
        if (!buildOrder.Orders.ContainsKey(atInterval))
            buildOrder.Orders.Add(atInterval, new List<EntityModel> { entity.Clone() });
        else
            buildOrder.Orders[atInterval].Add(entity.Clone());

        if (atInterval > lastInterval) lastInterval = atInterval;
    }

    public bool Add(EntityModel entity, IEconomyService withEconomy, IToastService withToasts)
    {
        var production = entity.Production();

        if (production != null)
        {
            for (var interval = lastInterval; interval < withEconomy.GetOverTime().Count; interval++)
            {
                var economyAtSecond = withEconomy.GetOverTime()[interval];
                if (economyAtSecond.Alloy >= production.Alloy && economyAtSecond.Ether >= production.Ether &&
                    economyAtSecond.Pyre >= production.Pyre)
                {
                    if (!MeetsSupply(entity))
                    {
                        withToasts.AddToast(new ToastModel
                        {
                            Title = "Supply Cap Reached", Message = "Build more supply!",
                            SeverityType = SeverityType.Error
                        });
                        return false;
                    }

                    if (!MeetsRequirements(entity, interval)) continue;

                    //Account for human Micro delay
                    interval += HumanMicro;

                    if (!buildOrder.Orders.ContainsKey(interval))
                        buildOrder.Orders.Add(interval, new List<EntityModel> { entity.Clone() });
                    else
                        buildOrder.Orders[interval].Add(entity.Clone());

                    lastInterval = interval;

                    NotifyDataChanged();
                    return true;
                }

                if (interval + 1 == withEconomy.GetOverTime().Count)
                {
                    if (economyAtSecond.Ether < production.Ether)
                        withToasts.AddToast(new ToastModel
                        {
                            Title = "Not Enough Ether", Message = "Build more ether extractors!",
                            SeverityType = SeverityType.Error
                        });
                }
            }
        }
        else
        {
            Add(entity, 0);
            NotifyDataChanged();
            return true;
        }

        return false;
    }

    public void RemoveLast()
    {
        EntityModel entityRemoved = null!;


        if (buildOrder.Orders.Keys.Count > 1)
        {
            var last = buildOrder.Orders.Keys.Last();

            if (buildOrder.Orders[last].Count > 0)
            {
                entityRemoved = buildOrder.Orders[last].Last();
                buildOrder.Orders[last].Remove(buildOrder.Orders[last].Last());
            }

            if (buildOrder.Orders[last].Count == 0) buildOrder.Orders.Remove(last);

            if (buildOrder.Orders.Keys.Count > 0)
                lastInterval = buildOrder.Orders.Keys.Last() + 1;
            else
                lastInterval = 1;

            if (entityRemoved?.Info()?.Descriptive == DescriptiveType.Worker)
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

    public List<EntityModel> GetOrdersAt(int interval)
    {
        return (from ordersAtTime in buildOrder.Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key == interval
            select orders).ToList();
    }

    public List<EntityModel> GetCompletedAt(int interval)
    {
        return (from ordersAtTime in buildOrder.Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) == interval
            select orders).ToList();
    }

    public List<EntityModel> GetCompletedBefore(int interval)
    {
        return (from ordersAtTime in buildOrder.Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            select orders).ToList();
    }

    public List<EntityModel> GetHarvestersCompletedBefore(int interval)
    {
        return (from ordersAtTime in buildOrder.Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            where orders.Harvest() != null
            select orders).ToList();
    }

    public bool MeetsRequirements(EntityModel entity, int requestedInterval)
    {
        var requirements = entity.Requirements();
        if (requirements.Count == 0) return true;

        foreach (var requirement in requirements)
            if (requirement.Requirement == RequirementType.Morph)
            {
                var entitiesNeeded = from entitiesAtInterval in buildOrder.Orders
                    from requiredEntity in entitiesAtInterval.Value
                    where requestedInterval > entitiesAtInterval.Key +
                        (requiredEntity.Production() == null ? 0 : requiredEntity.Production().BuildTime)
                    where requiredEntity.DataType == requirement.DataType
                    select requiredEntity;

                var entitiesAlreadyMorphed = from entitiesAtInterval in buildOrder.Orders
                    from existingEntity in entitiesAtInterval.Value
                    where existingEntity.DataType == entity.DataType
                    select existingEntity;

                if (entitiesAlreadyMorphed.Count() >= entitiesNeeded.Count())
                    return false;
            }
            else
            {
                var entitiesNeeded = from entitiesAtInterval in buildOrder.Orders
                    from requiredEntity in entitiesAtInterval.Value
                    where requestedInterval > entitiesAtInterval.Key +
                        (requiredEntity.Production() == null ? 0 : requiredEntity.Production().BuildTime)
                    where requiredEntity.DataType == requirement.DataType
                    select requiredEntity;


                if (!entitiesNeeded.Any()) return false;


                if (entitiesNeeded.Any() == false)
                    return false;
            }

        return true;
    }

    public void SetName(string Name)
    {
        buildOrder.Name = Name;
        NotifyDataChanged();
    }

    public string GetName()
    {
        return buildOrder.Name;
    }

    public void SetNotes(string Notes)
    {
        buildOrder.Notes = Notes;
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

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }

    public bool MeetsSupply(EntityModel entity)
    {
        var supply = entity.Supply();
        if (supply == null || supply.Takes == 0) return true;


        var supplyTakenTotal = 0;
        var supplyTakens = from entitiesAtInterval in buildOrder.Orders
            from supplyTakingEntity in entitiesAtInterval.Value
            where supplyTakingEntity.Supply()?.Takes > 0
            select supplyTakingEntity.Supply().Takes;
        foreach (var supplyTaken in supplyTakens) supplyTakenTotal += supplyTaken;

        var supplyGrantedTotal = 0;
        var supplyGranteds = from entitiesAtInterval in buildOrder.Orders
            from supplyGrantingEntity in entitiesAtInterval.Value
            where supplyGrantingEntity.Supply()?.Grants > 0
            select supplyGrantingEntity.Supply().Grants;
        foreach (var supplyGranted in supplyGranteds) supplyGrantedTotal += supplyGranted;

        if (supplyGrantedTotal > 160) supplyGrantedTotal = 160;

        if (supplyTakenTotal + supply.Takes > supplyGrantedTotal) return false;

        return true;
    }
}