using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityInfoModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityInfoModel";
    public string Name { get; set; } = "";
    public string Descriptive { get; set; } = DescriptiveType.None;
    public string Description { get; set; } = "";
    public string Notes { get; set; }
}