using System.Collections.Generic;
using System.Linq;
using Model.Entity;

namespace Model.BuildOrders;

public class BuildOrderModel
{
    public string Name { get; set; } = "";
    public string Color { get; set; } = "red";
    public string Notes { get; set; } = @"";

    public List<string> BuildTypes { get; set; } = new();
    public int CurrentSupplyUsed { get; set; } = 0;
    public Dictionary<int, List<EntityModel>> StartedOrders { get; set; } = new();
    public Dictionary<int, List<EntityModel>> CompletedOrders { get; set; } = new();
    public Dictionary<string, int> UniqueCompletedTimes { get; set; } = new();
    public Dictionary<string, int> UniqueCompletedCount { get; set; } = new();
    public Dictionary<int, int> SupplyCountTimes { get; set; } = new();
    
    public List<EntityModel> GetHarvestersCompletedBefore(int interval)
    {
        return (from ordersAtTime in StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            where orders.Harvest() != null
            select orders).ToList();
    }
}