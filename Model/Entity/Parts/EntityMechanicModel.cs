namespace Model.Entity.Parts;

public class EntityMechanicModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityMechanicModel";
    public string Name { get; set; } = "";
    public string Description { get; set; }
}