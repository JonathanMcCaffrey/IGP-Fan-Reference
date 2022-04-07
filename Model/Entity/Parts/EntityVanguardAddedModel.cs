using Model.Entity.Data;

namespace Model.Entity.Parts;

public class EntityVanguardAddedModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityVanguardAddedModel";

    public string ImmortalId { get; set; } = DataType.IMMORTAL_Ajari;

    public string ReplaceId { get; set; } = "";
}