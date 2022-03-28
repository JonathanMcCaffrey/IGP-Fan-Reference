using System;
using System.Collections.Generic;
using System.Linq;
using Model.Immortal.BuildOrders;
using Model.Immortal.Entity;
using Model.Immortal.Types;

namespace Model.Immortal.Economy;

public class EconomyOverTimeModel {
    public List<EconomyModel> EconomyOverTime { get; set; } = new();

    public void Calculate(BuildOrderModel buildOrder, int timing, int fromInterval) {
        if (EconomyOverTime == null) {
            EconomyOverTime = new List<EconomyModel>();
            for (var interval = 0; interval < timing; interval++)
                EconomyOverTime.Add(new EconomyModel { Interval = interval });
        }

        if (EconomyOverTime.Count > timing) EconomyOverTime.RemoveRange(timing, EconomyOverTime.Count - timing);

        while (EconomyOverTime.Count < timing)
            EconomyOverTime.Add(new EconomyModel { Interval = EconomyOverTime.Count - 1 });

        for (var interval = fromInterval; interval < timing; interval++) {
            var economyAtSecond = EconomyOverTime[interval];
            if (interval > 0) {
                economyAtSecond.Alloy = EconomyOverTime[interval - 1].Alloy;
                economyAtSecond.Ether = EconomyOverTime[interval - 1].Ether;
                economyAtSecond.WorkerCount = EconomyOverTime[interval - 1].WorkerCount;
                economyAtSecond.BusyWorkerCount = EconomyOverTime[interval - 1].BusyWorkerCount;
                economyAtSecond.CreatingWorkerCount = EconomyOverTime[interval - 1].CreatingWorkerCount;
                economyAtSecond.Harvesters = EconomyOverTime[interval - 1].Harvesters.ToList();
                economyAtSecond.CreatingWorkerDelays = EconomyOverTime[interval - 1].CreatingWorkerDelays.ToList();
            }

            economyAtSecond.Interval = interval;

            // Add funds
            float freeWorkers = economyAtSecond.WorkerCount - economyAtSecond.BusyWorkerCount;
            var workersNeeded = 0;

            economyAtSecond.Harvesters =
                (from harvester in buildOrder.GetHarvestersCompletedBefore(interval)
                    select harvester).ToList();

            // Add funds
            foreach (var entity in economyAtSecond.Harvesters) {
                var harvester = entity.Harvest();
                if (harvester.RequiresWorker)
                    if (harvester.Resource == ResourceType.Alloy) {
                        var usedWorkers = Math.Min(harvester.Slots, freeWorkers);
                        economyAtSecond.Alloy += harvester.HarvestedPerInterval * usedWorkers;
                        freeWorkers -= usedWorkers;

                        if (usedWorkers < harvester.Slots) workersNeeded += 1;
                    }

                if (harvester.RequiresWorker == false) {
                    if (harvester.Resource == ResourceType.Ether)
                        economyAtSecond.Ether += harvester.HarvestedPerInterval * harvester.Slots;

                    if (harvester.Resource == ResourceType.Alloy)
                        economyAtSecond.Alloy += harvester.HarvestedPerInterval * harvester.Slots;
                }
            }

            // Create new worker
            if (economyAtSecond.CreatingWorkerCount > 0)
                for (var i = 0; i < economyAtSecond.CreatingWorkerDelays.Count; i++)
                    if (economyAtSecond.CreatingWorkerDelays[i] > 0) {
                        if (economyAtSecond.Alloy > 2.5f) {
                            economyAtSecond.Alloy -= 2.5f;
                            economyAtSecond.CreatingWorkerDelays[i]--;
                        }
                    }
                    else {
                        economyAtSecond.CreatingWorkerCount -= 1;
                        economyAtSecond.WorkerCount += 1;
                        economyAtSecond.CreatingWorkerDelays.Remove(i);
                        i--;
                    }

            if (workersNeeded > economyAtSecond.CreatingWorkerCount) {
                economyAtSecond.CreatingWorkerCount += 1;
                economyAtSecond.CreatingWorkerDelays.Add(50);
            }

            // Remove Funds from Build Order
            var ordersAtTime = buildOrder.GetOrdersAt(interval);

            foreach (var order in ordersAtTime) {
                var foundEntity = EntityModel.GetDictionary()[order.DataType];
                var production = foundEntity.Production();

                if (production != null) {
                    economyAtSecond.Alloy -= production.Alloy;
                    economyAtSecond.Ether -= production.Ether;
                    var finishedAt = interval + production.BuildTime;

                    if (production.RequiresWorker) economyAtSecond.BusyWorkerCount += 1;
                }
            }

            // Handle new entities
            var completedAtInterval = buildOrder.GetCompletedAt(interval);
            foreach (var newEntity in completedAtInterval) {
                var harvest = newEntity;
                if (harvest != null) economyAtSecond.Harvesters.Add(harvest);

                var production = newEntity.Production();
                if (production != null && production.RequiresWorker) economyAtSecond.BusyWorkerCount -= 1;
            }
        }
    }
}