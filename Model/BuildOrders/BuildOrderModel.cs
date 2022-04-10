using System.Collections.Generic;
using System.Linq;
using Model.Entity;
using Model.Entity.Data;

namespace Model.BuildOrders;

public class BuildOrderModel
{
    public string Name { get; set; } = "";
    public string Color { get; set; } = "red";

    public Dictionary<int, List<EntityModel>> Orders { get; set; } = new()
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

    public string Notes { get; set; } = @"";

    public List<string> BuildTypes { get; set; } = new();


    public List<EntityModel> GetOrdersAt(int interval)
    {
        return (from ordersAtTime in Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key == interval
            select orders).ToList();
    }

    public List<EntityModel> GetCompletedAt(int interval)
    {
        return (from ordersAtTime in Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) == interval
            select orders).ToList();
    }

    public List<EntityModel> GetCompletedBefore(int interval)
    {
        return (from ordersAtTime in Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            select orders).ToList();
    }

    public List<EntityModel> GetHarvestersCompletedBefore(int interval)
    {
        return (from ordersAtTime in Orders
            from orders in ordersAtTime.Value
            where ordersAtTime.Key + (orders.Production() == null ? 0 : orders.Production().BuildTime) <= interval
            where orders.Harvest() != null
            select orders).ToList();
    }
}