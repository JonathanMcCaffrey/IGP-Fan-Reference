using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityHarvestModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityHarvestModel";
    public ResourceType Resource { get; set; } = ResourceType.Alloy;
    public float Slots { get; set; }
    public float HarvestedPerInterval { get; set; }
    public float HarvestDelay { get; set; } = 1;
    public int TotalAmount { get; set; }
    public bool RequiresWorker { get; set; }
}