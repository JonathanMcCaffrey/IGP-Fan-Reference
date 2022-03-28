namespace Model.Immortal.Entity.Parts;

public class EntityProductionModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityProductionModel";
    public int Alloy { get; set; } = 0;

    public int Ether { get; set; } = 0;

    public int Pyre { get; set; } = 0;

    public int Energy { get; set; } = 0;
    public int BuildTime { get; set; } = 0;

    // Remove cooldown as a cost, and move into ability stats
    public int Cooldown { get; set; } = 0;

    public bool RequiresWorker { get; set; } = false;
    public bool ConsumesWorker { get; set; } = false;
}