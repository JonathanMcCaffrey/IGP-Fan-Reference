using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityRequirementModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityRequirementModel";
    public string Name { get; set; } = "";
    public string DataType { get; set; }
    public string Requirement { get; set; } = RequirementType.Production_Building;
}