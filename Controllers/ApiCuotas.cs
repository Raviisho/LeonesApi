using LeonesApi.Data;
using LeonesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeonesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCuotas : ControllerBase
    {
        private readonly SmartsofMarcoslescanoContext _context;

        public ApiCuotas(SmartsofMarcoslescanoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuota>>> GetCuotas()
        {
            return await _context.Cuotas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuota>> GetCuota(int id)
        {
            var cuota = await _context.Cuotas.FindAsync(id);

            if (cuota == null)
            {
                return NotFound();
            }

            return cuota;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuota(int id, Cuota cuota)
        {
            if (id != cuota.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuotaExists(id))
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
        public async Task<ActionResult<Cuota>> PostCuota(Cuota cuota)
        {
            _context.Cuotas.Add(cuota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuota", new { id = cuota.Id }, cuota);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuota(int id)
        {
            var cuota = await _context.Cuotas.FindAsync(id);
            if (cuota == null)
            {
                return NotFound();
            }

            _context.Cuotas.Remove(cuota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuotaExists(int id)
        {
            return _context.Cuotas.Any(e => e.Id == id);
        }
    }
}