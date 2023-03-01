using LeonesApi.Data;
using LeonesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeonesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTesoreros : ControllerBase
    {
        private readonly SmartsofMarcoslescanoContext _context;

        public ApiTesoreros(SmartsofMarcoslescanoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tesorero>>> GetTesoreros()
        {
            return await _context.Tesoreros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tesorero>> GetTesoreros(int id)
        {
            var tesorero = await _context.Tesoreros.FindAsync(id);

            if (tesorero == null)
            {
                return NotFound();
            }

            return tesorero;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTesorero(int id, Tesorero tesorero)
        {
            if (id != tesorero.Id)
            {
                return BadRequest();
            }

            _context.Entry(tesorero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TesoreroExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Tesorero>> PostTesorero(Tesorero tesorero)
        {
            _context.Tesoreros.Add(tesorero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTesorero", new { id = tesorero.Id }, tesorero);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTesorero(int id)
        {
            var tesorero = await _context.Tesoreros.FindAsync(id);
            if (tesorero == null)
            {
                return NotFound();
            }

            _context.Tesoreros.Remove(tesorero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TesoreroExists(int id)
        {
            return _context.Tesoreros.Any(e => e.Id == id);
        }
    }
}
