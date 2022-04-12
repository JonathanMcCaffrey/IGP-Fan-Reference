using Model.Types;

namespace Model.Entity.Parts;

public class EntityRequirementModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityRequirementModel";
    public string Id { get; set; }
    public string Requirement { get; set; } = RequirementType.Production_Building;
}