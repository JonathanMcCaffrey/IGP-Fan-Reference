using System;
using System.Collections.Generic;

namespace Server.Model;

public partial class Entity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EntityWeapon> EntityWeapons { get; } = new List<EntityWeapon>();
}
