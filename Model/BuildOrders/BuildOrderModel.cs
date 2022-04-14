using System.Collections.Generic;
using System.Linq;
using Model.Entity;
using Model.Entity.Data;

namespace Model.BuildOrders;

public class BuildOrderModel
{
    public string Name { get; set; } = "";
    public string Color { get; set; } = "red";
    
    public int CurrentSupplyUsed { get; set; } = 0;

    public Dictionary<int, List<EntityModel>> StartedOrders { get; set; } = new()
    {
        {
            0,
            new List<EntityModel>
            {
                EntityModel.Get(DataType.STARTING_Bastion),
                EntityModel.Get(DataType.STARTING_TownHall_Aru)
            }
        }
    };
    
    public Dictionary<int, List<EntityModel>> CompletedOrders { get; set; } = new()
    {
        {
            0,
            new List<EntityModel>
            {
                EntityModel.Get(DataType.STARTING_Bastion),
                EntityModel.Get(DataType.STARTING_TownHall_Aru)
            }
        }
    };
    
    public Dictionary<string, int> UniqueCompletedTimes { get; set; } = new()
    {
        {
            DataType.STARTING_Bastion, 0
        }
    };
    
    public Dictionary<string, int> UniqueCompletedCount { get; set; } = new()
    {
        {
            DataType.STARTING_Bastion, 1
        }
    };
    
    
    
    public Dictionary<int, int> SupplyCountTimes { get; set; } = new()
    {
        {
            0, 0
        }
    };

    public string Notes { get; set; } = @"";

    public List<string> BuildTypes { get; set; } = new();


    public List<EntityModel> GetCompletedBefore(int interval)
    {
        return (from ordersAtTime in StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key >= interval
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            select orders).ToList();
    }

    public List<EntityModel> GetHarvestersCompletedBefore(int interval)
    {
        return (from ordersAtTime in StartedOrders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            where orders.Harvest() != null
            select orders).ToList();
    }
}