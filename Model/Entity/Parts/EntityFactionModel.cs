using Model.Types;

namespace Model.Entity.Parts;

public class EntityFactionModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityFactionModel";
    public string Faction { get; set; } = FactionType.QRath;
}