using Model.Immortal.Entity.Data;
using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityVanguardReplacedModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityVanguardReplacedModel";
    public string ImmortalId { get; set; } = DataType.IMMORTAL_Xol;
    public string ReplacedById { get; set; } = "";
}