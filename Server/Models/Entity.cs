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


public static class EntityEndpoints
{
	public static void MapEntityEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Entity");
        group.MapGet("/", async (JonathanMccaffreyContext db) =>
        {
            return await db.Entities.ToListAsync();
        })
        .WithName("GetAllEntitys");

        group.MapGet("/{id}", async  (int id, JonathanMccaffreyContext db) =>
        {
            return await db.Entities.FindAsync(id)
                is Entity model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetEntityById");

        group.MapPut("/{id}", async  (int id, Entity entity, JonathanMccaffreyContext db) =>
        {
            var foundModel = await db.Entities.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateEntity");

        group.MapPost("/", async (Entity entity, JonathanMccaffreyContext db) =>
        {
            db.Entities.Add(entity);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Entity/{entity.Id}",entity);
        })
        .WithName("CreateEntity");

        group.MapDelete("/{id}", async  (int id, JonathanMccaffreyContext db) =>
        {
            if (await db.Entities.FindAsync(id) is Entity entity)
            {
                db.Entities.Remove(entity);
                await db.SaveChangesAsync();
                return Results.Ok(entity);
            }

            return Results.NotFound();
        })
        .WithName("DeleteEntity");
    }
}