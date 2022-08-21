using Model.Entity.Data;

namespace Model.BuildOrders;

public class TrainingSlot
{
    public int StartingInterval { get; set; } = 30;
    public int Slots { get; set; } = 10;
    public string ProductionType { get; set; } = DataType.BUILDING_LegionHall;
}