using System;
using System.Collections.Generic;

namespace Server.Model;

public partial class EntityWeapon
{
    public int Id { get; set; }

    public int? Range { get; set; }

    public double? AttacksPerSecond { get; set; }

    public double? Cooldown { get; set; }

    public double? Charges { get; set; }

    public int? Damage { get; set; }

    public bool? HasSplash { get; set; }

    public int? LightDamage { get; set; }

    public int? HeavyDamage { get; set; }

    public int? StructureDamageBonus { get; set; }

    public int? EthericDamageBonus { get; set; }

    public string? Targets { get; set; }

    public int? EntityId { get; set; }

    public virtual Entity? Entity { get; set; }
}
