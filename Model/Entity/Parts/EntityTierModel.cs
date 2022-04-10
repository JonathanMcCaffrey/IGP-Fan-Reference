namespace Model.Entity.Parts;

public class EntityTierModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityTierModel";
    public float Tier { get; set; }
}