using LeonesApi.Data;
using LeonesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeonesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSocios : ControllerBase
    {
        private readonly SmartsofMarcoslescanoContext _context;

        public ApiSocios(SmartsofMarcoslescanoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Socio>>> GetSocios()
        {
            return await _context.Socios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Socio>> GetSocio(int id)
        {
            var socio = await _context.Socios.FindAsync(id);

            if (socio == null)
            {
                return NotFound();
            }

            return socio;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocio(int id, Socio socio)
        {
            if (id != socio.Id)
            {
                return BadRequest();
            }

            _context.Entry(socio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocioExists(id))
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
        public async Task<ActionResult<Socio>> PostSocio(Socio socio)
        {
            _context.Socios.Add(socio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocio", new { id = socio.Id }, socio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocio(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }

            _context.Socios.Remove(socio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(e => e.Id == id);
        }
    }
}
