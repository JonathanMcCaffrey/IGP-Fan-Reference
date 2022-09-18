using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Model;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityWeaponsController : ControllerBase
    {
        private readonly JonathanMccaffreyContext _context;

        public EntityWeaponsController(JonathanMccaffreyContext context)
        {
            _context = context;
        }

        // GET: api/EntityWeapons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityWeapon>>> GetEntityWeapons()
        {
            return await _context.EntityWeapons.ToListAsync();
        }

        // GET: api/EntityWeapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityWeapon>> GetEntityWeapon(int id)
        {
            var entityWeapon = await _context.EntityWeapons.FindAsync(id);

            if (entityWeapon == null)
            {
                return NotFound();
            }

            return entityWeapon;
        }

        // PUT: api/EntityWeapons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityWeapon(int id, EntityWeapon entityWeapon)
        {
            if (id != entityWeapon.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityWeapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityWeaponExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EntityWeapons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntityWeapon>> PostEntityWeapon(EntityWeapon entityWeapon)
        {
            _context.EntityWeapons.Add(entityWeapon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityWeapon", new { id = entityWeapon.Id }, entityWeapon);
        }

        // DELETE: api/EntityWeapons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityWeapon(int id)
        {
            var entityWeapon = await _context.EntityWeapons.FindAsync(id);
            if (entityWeapon == null)
            {
                return NotFound();
            }

            _context.EntityWeapons.Remove(entityWeapon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityWeaponExists(int id)
        {
            return _context.EntityWeapons.Any(e => e.Id == id);
        }
    }
}
