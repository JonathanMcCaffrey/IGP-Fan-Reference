using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityVanguardAddedModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityVanguardAddedModel";
    public string Immortal { get; set; } = ImmortalType.Ajari;
    public string Replaces { get; set; } = "";
}