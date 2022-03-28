using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityMovementModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityMovementModel";
    public float Speed { get; set; } = 0;
    public string Movement { get; set; } = MovementType.Ground;
}