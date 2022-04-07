namespace Model.Entity.Parts;

public class EntitySupplyModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntitySupplyModel";
    public int Takes { get; set; } = 0;
    public int Grants { get; set; } = 0;
}