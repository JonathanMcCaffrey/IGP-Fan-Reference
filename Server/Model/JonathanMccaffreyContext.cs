using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.Model;

public partial class JonathanMccaffreyContext : DbContext
{
    public JonathanMccaffreyContext()
    {
    }

    public JonathanMccaffreyContext(DbContextOptions<JonathanMccaffreyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entity> Entities { get; set; } = null!;

    public virtual DbSet<EntityWeapon> EntityWeapons { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:IGP");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>(entity =>
        {
            entity.ToTable("Entity", "igp");

            entity.Property(e => e.Id)
                .HasColumnOrder(0)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnOrder(1)
                .HasColumnName("name");
        });

        modelBuilder.Entity<EntityWeapon>(entity =>
        {
            entity.ToTable("EntityWeapon", "igp");

            entity.Property(e => e.Id)
                .HasColumnOrder(0)
                .HasColumnName("id");
            entity.Property(e => e.AttacksPerSecond)
                .HasColumnOrder(2)
                .HasColumnName("attacksPerSecond");
            entity.Property(e => e.Charges)
                .HasColumnOrder(4)
                .HasColumnName("charges");
            entity.Property(e => e.Cooldown)
                .HasColumnOrder(3)
                .HasColumnName("cooldown");
            entity.Property(e => e.Damage)
                .HasColumnOrder(5)
                .HasColumnName("damage");
            entity.Property(e => e.EntityId)
                .HasColumnOrder(12)
                .HasColumnName("entityId");
            entity.Property(e => e.EthericDamageBonus)
                .HasColumnOrder(10)
                .HasColumnName("ethericDamageBonus");
            entity.Property(e => e.HasSplash)
                .HasColumnOrder(6)
                .HasColumnName("hasSplash");
            entity.Property(e => e.HeavyDamage)
                .HasColumnOrder(8)
                .HasColumnName("heavyDamage");
            entity.Property(e => e.LightDamage)
                .HasColumnOrder(7)
                .HasColumnName("lightDamage");
            entity.Property(e => e.Range)
                .HasColumnOrder(1)
                .HasColumnName("range");
            entity.Property(e => e.StructureDamageBonus)
                .HasColumnOrder(9)
                .HasColumnName("structureDamageBonus");
            entity.Property(e => e.Targets)
                .HasMaxLength(50)
                .HasColumnOrder(11)
                .HasColumnName("targets");

            entity.HasOne(d => d.Entity).WithMany(p => p.EntityWeapons)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_Entity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
