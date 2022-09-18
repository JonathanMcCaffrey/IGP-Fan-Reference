using System;
using System.Collections.Generic;
using Server.Model;
using Microsoft.EntityFrameworkCore;

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


public static class EntityWeaponEndpoints
{
	public static void MapEntityWeaponEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/EntityWeapon");
        group.MapGet("/", async (JonathanMccaffreyContext db) =>
        {
            return await db.EntityWeapons.ToListAsync();
        })
        .WithName("GetAllEntityWeapons");

        group.MapGet("/{id}", async  (int id, JonathanMccaffreyContext db) =>
        {
            return await db.EntityWeapons.FindAsync(id)
                is EntityWeapon model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetEntityWeaponById");

        group.MapPut("/{id}", async  (int id, EntityWeapon entityWeapon, JonathanMccaffreyContext db) =>
        {
            var foundModel = await db.EntityWeapons.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateEntityWeapon");

        group.MapPost("/", async (EntityWeapon entityWeapon, JonathanMccaffreyContext db) =>
        {
            db.EntityWeapons.Add(entityWeapon);
            await db.SaveChangesAsync();
            return Results.Created($"/api/EntityWeapon/{entityWeapon.Id}",entityWeapon);
        })
        .WithName("CreateEntityWeapon");

        group.MapDelete("/{id}", async  (int id, JonathanMccaffreyContext db) =>
        {
            if (await db.EntityWeapons.FindAsync(id) is EntityWeapon entityWeapon)
            {
                db.EntityWeapons.Remove(entityWeapon);
                await db.SaveChangesAsync();
                return Results.Ok(entityWeapon);
            }

            return Results.NotFound();
        })
        .WithName("DeleteEntityWeapon");
    }
}