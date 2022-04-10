using Model.Entity.Data;

namespace Model.Entity.Parts;

public class EntityVanguardReplacedModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityVanguardReplacedModel";
    public string ImmortalId { get; set; } = DataType.IMMORTAL_Xol;
    public string ReplacedById { get; set; } = "";
}