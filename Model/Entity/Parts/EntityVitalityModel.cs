using Model.Types;

namespace Model.Entity.Parts;

public class EntityVitalityModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityVitalityModel";
    public int Health { get; set; } = 0;
    public int DefenseLayer { get; set; } = 0;
    public string Defense { get; set; } = DefenseType.None;
    public string Armor { get; set; } = ArmorType.Light;
    public bool IsEtheric { get; set; } = false;
    public bool IsStructure { get; set; } = false;

    public int Energy { get; set; } = 0;
}