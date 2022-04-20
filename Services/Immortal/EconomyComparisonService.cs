using Model.BuildOrders;
using Model.Economy;
using Model.Entity;
using Model.Entity.Data;
using Model.Types;

namespace Services.Immortal;

public class EconomyComparisionService : IEconomyComparisonService
{
    private readonly int IntervalMax = 1024;

    public EconomyComparisionService()
    {
        BuildsToCompare = new List<BuildToCompareModel>
        {
            new() { NumberOfTownHallExpansions = 0, Faction = DataType.FACTION_Aru, ChartColor = "green" },
            new() { NumberOfTownHallExpansions = 0, Faction = DataType.FACTION_Aru, ChartColor = "red" }
        };

        BuildsToCompare[0].EconomyOverTimeModel = CalculateEconomy(BuildsToCompare[0]);
        BuildsToCompare[1].EconomyOverTimeModel = CalculateEconomy(BuildsToCompare[1]);
    }

    public List<BuildToCompareModel> BuildsToCompare { get; set; }


    public void ChangeNumberOfTownHalls(int forPlayer, int toCount)
    {
        if (BuildsToCompare[forPlayer].NumberOfTownHallExpansions == toCount) return;

        BuildsToCompare[forPlayer].NumberOfTownHallExpansions = toCount;

        CalculateBuildOrder(BuildsToCompare[forPlayer]);

        NotifyDataChanged();
    }

    public void ChangeTownHallTiming(int forPlayer, int forTownHall, int toTiming)
    {
        if (BuildsToCompare[forPlayer].TimeToBuildTownHall[forTownHall] == toTiming) return;

        BuildsToCompare[forPlayer].TimeToBuildTownHall[forTownHall] = toTiming;

        CalculateBuildOrder(BuildsToCompare[forPlayer]);

        NotifyDataChanged();
    }

    public int GetTownHallCount(int forPlayer)
    {
        return BuildsToCompare[forPlayer].NumberOfTownHallExpansions;
    }

    public int GetTownHallBuildTime(int forPlayer, int forTownHall)
    {
        return BuildsToCompare[forPlayer].TimeToBuildTownHall[forTownHall];
    }

    public List<int> GetTownHallBuildTimes(int forPlayer)
    {
        return BuildsToCompare[forPlayer].TimeToBuildTownHall;
    }

    public void ChangeFaction(int forPlayer, string toFaction)
    {
        if (BuildsToCompare[forPlayer].Faction.Equals(toFaction)) return;

        BuildsToCompare[forPlayer].Faction = toFaction;
        NotifyDataChanged();
    }

    public string GetFaction(int forPlayer)
    {
        return BuildsToCompare[forPlayer].Faction;
    }

    public void ChangeColor(int forPlayer, string toColor)
    {
        if (BuildsToCompare[forPlayer].ChartColor.Equals(toColor)) return;

        BuildsToCompare[forPlayer].ChartColor = toColor;
        NotifyDataChanged();
    }

    public string GetColor(int forPlayer)
    {
        return BuildsToCompare[forPlayer].ChartColor;
    }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }


    private void CalculateBuildOrder(BuildToCompareModel buildToCompare)
    {
        buildToCompare.BuildOrderModel = new BuildOrderModel(buildToCompare.Faction);

        foreach (var time in buildToCompare.TimeToBuildTownHall)
        {
            var townHall = buildToCompare.GetTownHallEntity;
            var townHallMining2 = buildToCompare.GetTownHallMining2Entity;
            var townHallMining3 = buildToCompare.GetTownHallMining3Entity;

            Add(townHall, buildToCompare, time);
            Add(townHallMining2, buildToCompare, time + townHall.Production()!.BuildTime);
            Add(townHallMining3, buildToCompare,
                time + townHall.Production()!.BuildTime + townHallMining2.Production()!.BuildTime);
        }

        CalculateEconomy(buildToCompare);
    }

    public void Add(EntityModel entityModel, BuildToCompareModel buildToCompare, int atInterval)
    {
        var buildOrder = buildToCompare.BuildOrderModel;


        if (!buildOrder.StartedOrders.ContainsKey(atInterval))
            buildOrder.StartedOrders.Add(atInterval, new List<EntityModel>());

        var production = entityModel.Production();

        var completedTime = atInterval;
        if (production != null) completedTime += production.BuildTime;

        if (!buildOrder.CompletedOrders.ContainsKey(completedTime))
            buildOrder.CompletedOrders.Add(completedTime, new List<EntityModel>());

        buildOrder.StartedOrders[atInterval].Add(entityModel.Clone());
        buildOrder.CompletedOrders[completedTime].Add(entityModel.Clone());

        NotifyDataChanged();
    }

    private List<EconomyModel> CalculateEconomy(BuildToCompareModel buildToCompare, int fromInterval = 0)
    {
        // We don't consider things mining at zero seconds
        if (fromInterval == 0) fromInterval = 1;

        var buildOrder = buildToCompare.BuildOrderModel;

        List<EconomyModel> buildEconomyOverTime = buildToCompare.EconomyOverTimeModel;

        while (buildEconomyOverTime.Count < IntervalMax)
            buildEconomyOverTime.Add(new EconomyModel { Interval = buildEconomyOverTime.Count - 1 });

        for (var interval = fromInterval; interval < IntervalMax; interval++)
        {
            buildEconomyOverTime[interval] = new EconomyModel();
            var economyAtSecond = buildEconomyOverTime[interval];
            if (interval > 0)
            {
                economyAtSecond.Alloy = buildEconomyOverTime[interval - 1].Alloy;
                economyAtSecond.Ether = buildEconomyOverTime[interval - 1].Ether;
                economyAtSecond.Pyre = buildEconomyOverTime[interval - 1].Pyre;
                economyAtSecond.WorkerCount = buildEconomyOverTime[interval - 1].WorkerCount;
                economyAtSecond.BusyWorkerCount = buildEconomyOverTime[interval - 1].BusyWorkerCount;
                economyAtSecond.CreatingWorkerCount = buildEconomyOverTime[interval - 1].CreatingWorkerCount;
                economyAtSecond.HarvestPoints = buildEconomyOverTime[interval - 1].HarvestPoints.ToList();
                economyAtSecond.CreatingWorkerDelays = buildEconomyOverTime[interval - 1].CreatingWorkerDelays.ToList();
            }

            economyAtSecond.Interval = interval;

            // Add funds
            float freeWorkers = economyAtSecond.WorkerCount - economyAtSecond.BusyWorkerCount;
            var workersNeeded = 0;

            economyAtSecond.HarvestPoints =
                (from harvester in buildOrder.GetHarvestersCompletedBefore(interval)
                    select harvester).ToList();

            // Add funds
            economyAtSecond.Pyre += 1;

            // Add funds
            foreach (var entity in economyAtSecond.HarvestPoints)
            {
                var harvester = entity.Harvest();
                if (harvester.RequiresWorker)
                    if (harvester.Resource == ResourceType.Alloy)
                    {
                        var usedWorkers = Math.Min(harvester.Slots, freeWorkers);
                        economyAtSecond.Alloy += harvester.HarvestedPerInterval * usedWorkers;
                        freeWorkers -= usedWorkers;

                        if (usedWorkers < harvester.Slots) workersNeeded += 1;
                    }

                if (harvester.RequiresWorker == false)
                {
                    if (harvester.Resource == ResourceType.Ether)
                        economyAtSecond.Ether += harvester.HarvestedPerInterval * harvester.Slots;

                    if (harvester.Resource == ResourceType.Alloy)
                        economyAtSecond.Alloy += harvester.HarvestedPerInterval * harvester.Slots;
                }
            }

            // Create new worker
            if (economyAtSecond.CreatingWorkerCount > 0)
                for (var i = 0; i < economyAtSecond.CreatingWorkerDelays.Count; i++)
                    if (economyAtSecond.CreatingWorkerDelays[i] > 0)
                    {
                        if (economyAtSecond.Alloy > 2.5f)
                        {
                            economyAtSecond.Alloy -= 2.5f;
                            economyAtSecond.CreatingWorkerDelays[i]--;
                        }
                    }
                    else
                    {
                        economyAtSecond.CreatingWorkerCount -= 1;
                        economyAtSecond.WorkerCount += 1;
                        economyAtSecond.CreatingWorkerDelays.Remove(i);
                        i--;
                    }

            if (workersNeeded > economyAtSecond.CreatingWorkerCount)
            {
                economyAtSecond.CreatingWorkerCount += 1;
                economyAtSecond.CreatingWorkerDelays.Add(50);
            }

            // Remove Funds from Build Order

            if (buildOrder.StartedOrders.TryGetValue(interval, out var ordersAtTime))
                foreach (var order in ordersAtTime)
                {
                    var foundEntity = EntityModel.GetDictionary()[order.DataType];
                    var production = foundEntity.Production();

                    if (production != null)
                    {
                        economyAtSecond.Alloy -= production.Alloy;
                        economyAtSecond.Ether -= production.Ether;
                        economyAtSecond.Pyre -= production.Pyre;
                        var finishedAt = interval + production.BuildTime;

                        if (production.RequiresWorker) economyAtSecond.BusyWorkerCount += 1;

                        if (production.ConsumesWorker) economyAtSecond.WorkerCount -= 1;
                    }
                }

            // Handle new entities
            if (buildOrder.CompletedOrders.TryGetValue(interval, out var completedAtInterval))
                foreach (var newEntity in completedAtInterval)
                {
                    var harvest = newEntity;
                    if (harvest != null) economyAtSecond.HarvestPoints.Add(harvest);

                    var production = newEntity.Production();
                    if (production != null && production.RequiresWorker) economyAtSecond.BusyWorkerCount -= 1;
                }
        }

        return buildEconomyOverTime;
    }


    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange();
    }
}