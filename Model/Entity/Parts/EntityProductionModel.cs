#nullable enable
namespace Model.Entity.Parts;

public class EntityProductionModel : IEntityPartInterface
{
    public int Alloy { get; set; } = 0;
    public int Ether { get; set; } = 0;
    public int Pyre { get; set; } = 0;
    public int Energy { get; set; } = 0;
    public int DefensiveLayer { get; set; } = 0;
    public int BuildTime { get; set; } = 0;
    public float Cooldown { get; set; } = 0;
    public bool RequiresWorker { get; set; } = false;
    public bool ConsumesWorker { get; set; } = false;

    //public string ProductionType { get; set; }
    public string? ProducedBy { get; set; } = null;
}