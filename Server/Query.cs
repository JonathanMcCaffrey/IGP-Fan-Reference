using Server.Model;

namespace Server
{

    public class Query
    {
        [UseProjection]
        public IEnumerable<Entity> GetEntities([Service] JonathanMccaffreyContext context) =>
            context.Entities.Select(entity => new Entity()
            {
                Id = entity.Id,
                Name = entity.Name,
                EntityWeapons = entity.EntityWeapons

            });

        public IEnumerable<EntityWeapon> GetEntityWeapons([Service] JonathanMccaffreyContext context) =>
            context.EntityWeapons.Select(weapon => new EntityWeapon()
            {
                Id = weapon.Id,
                AttacksPerSecond = weapon.AttacksPerSecond,
                Charges = weapon.Charges,
                Cooldown = weapon.Cooldown,
                Damage = weapon.Damage,
                EntityId = weapon.EntityId,
                EthericDamageBonus = weapon.EthericDamageBonus,
                HasSplash = weapon.HasSplash,
                HeavyDamage = weapon.HeavyDamage,
                LightDamage = weapon.LightDamage,
                Range = weapon.Range,
                StructureDamageBonus = weapon.StructureDamageBonus,
                Targets = weapon.Targets,
                Entity = weapon.Entity
            });
    }
}
