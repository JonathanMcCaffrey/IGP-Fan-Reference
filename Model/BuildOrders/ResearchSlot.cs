using Model.Entity.Data;

namespace Model.BuildOrders;

public class ResearchSlot
{
    public int StartingInterval { get; set; } = 30;
    public int Slots { get; set; } = 1;
    public string ResearchType { get; set; } = DataType.BUILDING_Reliquary;
}