using System;
using Model.Immortal.Entity.Data;
using Model.Immortal.Types;

namespace Model.Immortal.Entity.Parts;

public class EntityVanguardAddedModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityVanguardAddedModel";
    
    public string ImmortalId { get; set; } = DataType.IMMORTAL_Ajari;
    
    public string ReplaceId { get; set; } = "";
}