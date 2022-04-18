using Model.BuildOrders;
using Model.Economy;
using Model.Entity;
using Model.Types;

namespace Services.Immortal;

public class EconomyService : IEconomyService
{
    private List<EconomyModel> buildEconomyOverTime = null!;
    
    private Dictionary<string, List<EconomyModel>> specficEconomiesOverTime = null!;

    public List<EconomyModel> GetOverTime()
    {
        return buildEconomyOverTime;
    }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }

    public void Calculate(IBuildOrderService buildOrder, ITimingService timing, int fromInterval)
    {
        // We don't consider things mining at zero seconds
        if (fromInterval == 0)
        {
            fromInterval = 1;
        }
        
        //TODO Break all this up
        if (buildEconomyOverTime == null)
        {
            buildEconomyOverTime = new List<EconomyModel>();
            for (var interval = 0; interval < timing.GetAttackTime(); interval++)
                buildEconomyOverTime.Add(new EconomyModel { Interval = interval });
        }


        if (buildEconomyOverTime.Count > timing.GetAttackTime())
            buildEconomyOverTime.RemoveRange(timing.GetAttackTime(), buildEconomyOverTime.Count - timing.GetAttackTime());

        while (buildEconomyOverTime.Count < timing.GetAttackTime())
            buildEconomyOverTime.Add(new EconomyModel { Interval = buildEconomyOverTime.Count - 1 });

        for (var interval = fromInterval; interval < timing.GetAttackTime(); interval++)
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
                economyAtSecond.Harvesters = buildEconomyOverTime[interval - 1].Harvesters.ToList();
                economyAtSecond.CreatingWorkerDelays = buildEconomyOverTime[interval - 1].CreatingWorkerDelays.ToList();
            }

            economyAtSecond.Interval = interval;

            // Add funds
            float freeWorkers = economyAtSecond.WorkerCount - economyAtSecond.BusyWorkerCount;
            var workersNeeded = 0;

            economyAtSecond.Harvesters =
                (from harvester in buildOrder.GetHarvestersCompletedBefore(interval)
                    select harvester).ToList();

            // Add funds
            economyAtSecond.Pyre += 1;

            // Add funds
            foreach (var entity in economyAtSecond.Harvesters)
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
                    if (harvest != null) economyAtSecond.Harvesters.Add(harvest);

                    var production = newEntity.Production();
                    if (production != null && production.RequiresWorker) economyAtSecond.BusyWorkerCount -= 1;
                }
        }

        NotifyDataChanged();
    }


    
    
    public EconomyModel GetEconomy(int atInterval)
    {
        if (atInterval >= buildEconomyOverTime.Count) return buildEconomyOverTime.Last();

        return buildEconomyOverTime[atInterval];
    }


    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}