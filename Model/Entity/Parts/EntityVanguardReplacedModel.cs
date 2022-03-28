using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityVanguardReplacedModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityVanguardReplacedModel";
    public string Immortal { get; set; } = ImmortalType.Ajari;
    public string ReplacedBy { get; set; } = "";
}