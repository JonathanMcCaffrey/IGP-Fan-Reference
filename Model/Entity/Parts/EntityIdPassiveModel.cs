namespace Model.Entity.Parts;

public class EntityIdPassiveModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityIdPassiveModel";
    public string Id { get; set; }
}