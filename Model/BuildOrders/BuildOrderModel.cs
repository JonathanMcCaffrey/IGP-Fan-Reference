using System;
using System.Collections.Generic;
using System.Linq;
using Model.Entity;
using Model.Entity.Data;

namespace Model.BuildOrders;

public class BuildOrderModel
{
    public BuildOrderModel()
    {
        Initialize(DataType.FACTION_QRath);
    }

    public BuildOrderModel(string factionType)
    {
        Initialize(factionType);
    }

    public string Name { get; set; } = "";
    public string Notes { get; set; } = @"";

    public List<string> BuildTypes { get; set; } = new();
    public int CurrentSupplyUsed { get; set; } = 0;
    public Dictionary<int, List<EntityModel>> StartedOrders { get; set; } = new();
    public Dictionary<int, List<EntityModel>> CompletedOrders { get; set; } = new();
    public Dictionary<string, int> UniqueCompletedTimes { get; set; } = new();
    public Dictionary<string, int> UniqueCompletedCount { get; set; } = new();
    public Dictionary<int, int> SupplyCountTimes { get; set; } = new();

    public Dictionary<string, List<EntityModel>> UniqueCompleted { get; set; } = new();

    public List<TrainingCapacityUsedModel> TrainingCapacityUsed { get; set; } = new();

    public void Initialize(string faction)
    {
        var factionStartingTownHall = faction.Equals(DataType.FACTION_QRath) ? DataType.STARTING_TownHall_QRath :
            faction.Equals(DataType.FACTION_Aru) ? DataType.STARTING_TownHall_Aru : "";

        if (factionStartingTownHall.Equals("")) throw new Exception("Reminder to add support to new factions");

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
        };
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
        };
        UniqueCompletedTimes = new Dictionary<string, int>
        {
            {
                DataType.STARTING_Bastion, 0
            },
            {
                DataType.STARTING_TownHall_Aru, 0
            }
        };
        UniqueCompletedCount = new Dictionary<string, int>
        {
            {
                DataType.STARTING_Bastion, 1
            },
            {
                DataType.STARTING_TownHall_Aru, 1
            }
        };
        SupplyCountTimes = new Dictionary<int, int>
        {
            {
                0, 0
            }
        };
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