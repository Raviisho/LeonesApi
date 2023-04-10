using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeonesApi.Data;
using LeonesApi.Models;

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

        // GET: api/ApiCuotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuota>>> GetCuotas()
        {
          if (_context.Cuotas == null)
          {
              return NotFound();
          }
            return await _context.Cuotas.ToListAsync();
        }

        // GET: api/ApiCuotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuota>> GetCuota(int id)
        {
          if (_context.Cuotas == null)
          {
              return NotFound();
          }
            var cuota = await _context.Cuotas.FindAsync(id);

            if (cuota == null)
            {
                return NotFound();
            }

            return cuota;
        }

        // PUT: api/ApiCuotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/ApiCuotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuota>> PostCuota(Cuota cuota)
        {
          if (_context.Cuotas == null)
          {
              return Problem("Entity set 'SmartsofMarcoslescanoContext.Cuotas'  is null.");
          }
            _context.Cuotas.Add(cuota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuota", new { id = cuota.Id }, cuota);
        }

        // DELETE: api/ApiCuotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuota(int id)
        {
            if (_context.Cuotas == null)
            {
                return NotFound();
            }
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
            return (_context.Cuotas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
