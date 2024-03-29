﻿using Model.Entity.Types;
using Model.Types;

namespace Model.Entity.Parts;

public class EntityWeaponModel : IEntityPartInterface
{
    public int Id { get; set; } = 1;
    public int EntityModelId { get; set; }
    public virtual EntityModel EntityModel { get; set; }

    public int Range { get; set; } = 40;
    public float AttacksPerSecond { get; set; } = 0;
    public float SecondsBetweenAttacks { get; set; } = 0;

    public float Cooldown { get; set; } = 0;
    public float Charges { get; set; } = 0;

    public int Damage { get; set; } = 0;
    
    public string ComplexDamage { get; set; } = "deals 126 over 6 seconds";


    public bool HasSplash { get; set; }

    public int LightDamage { get; set; } = 0;
    public int MediumDamage { get; set; } = 0;
    public int HeavyDamage { get; set; } = 0;


    public int StructureDamageBonus { get; set; } = 0;
    public int EthericDamageBonus { get; set; } = 0;
    public string Targets { get; set; } = TargetType.All;
    public string Attack { get; set; } = AttackType.DPS;
}