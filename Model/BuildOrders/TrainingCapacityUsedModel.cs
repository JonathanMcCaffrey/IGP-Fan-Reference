using Model.Entity.Data;

namespace Model.BuildOrders;

public class TrainingCapacityUsedModel
{
    public int UsedSlots { get; set; } = 4;
    public string UsedBuilding { get; set; } = DataType.BUILDING_LegionHall;
    public int StartingUsageTime { get; set; } = 30;
    public int StopUsageTime { get; set; } = 60;
}