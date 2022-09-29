using System;
using System.Collections.Generic;
using Server.Model;
using Microsoft.EntityFrameworkCore;

namespace Server.Model;

public partial class Entity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EntityWeapon> EntityWeapons { get; set; } = new List<EntityWeapon>();
}
