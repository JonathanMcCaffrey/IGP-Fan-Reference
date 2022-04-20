using System.Collections.Generic;
using System.Linq;
using Model.Economy;
using Model.Entity;
using Model.Entity.Data;

namespace Model.BuildOrders;

public class BuildToCompareModel
{
    private int numberOfTownHallExpansions;
    public string Faction { get; set; }

    public EntityModel GetTownHallEntity => DATA.Get()[
        Faction.Equals(DataType.FACTION_QRath)
            ? DataType.BUILDING_Acropolis
            : DataType.BUILDING_GroveHeart];

    public EntityModel GetTownHallMining2Entity => DATA.Get()[
        Faction.Equals(DataType.FACTION_QRath)
            ? DataType.BUPGRADE_MiningLevel2_QRath
            : DataType.BUPGRADE_MiningLevel2_Aru];

    public EntityModel GetTownHallMining3Entity => DATA.Get()[
        Faction.Equals(DataType.FACTION_QRath)
            ? DataType.BUPGRADE_MiningLevel3_QRath
            : DataType.BUPGRADE_MiningLevel3_Aru];

    public int NumberOfTownHallExpansions
    {
        get => numberOfTownHallExpansions;
        set
        {
            if (value >= 0 && value < 6 && value != numberOfTownHallExpansions)
            {
                numberOfTownHallExpansions = value;
                while (TimeToBuildTownHall.Count < numberOfTownHallExpansions)
                    TimeToBuildTownHall.Add((TimeToBuildTownHall.Count + 1) * 30);
                while (TimeToBuildTownHall.Count > numberOfTownHallExpansions)
                    TimeToBuildTownHall.Remove(TimeToBuildTownHall.Last());
            }
        }
    }

    public List<int> TimeToBuildTownHall { get; set; } = new();

    public List<EconomyModel> EconomyOverTimeModel { get; set; } = new();

    public BuildOrderModel BuildOrderModel { get; set; } = new();

    public string ChartColor { get; set; }
}