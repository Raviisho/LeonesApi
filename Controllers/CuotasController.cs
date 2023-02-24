using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeonesApi.Models;
using LeonesApi.Data;

namespace LeonesApi.Controllers
{
    public class CuotasController : Controller
    {
        private readonly SmartsofMarcoslescanoContext _context;

        public CuotasController(SmartsofMarcoslescanoContext context)
        {
            _context = context;
        }

        // GET: Cuotas
        public async Task<IActionResult> Index()
        {
            var smartsofMarcoslescanoContext = _context.Cuotas.Include(c => c.Socio).Include(c => c.Tesorero);
            return View(await smartsofMarcoslescanoContext.ToListAsync());
        }

        // GET: Cuotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cuotas == null)
            {
                return NotFound();
            }

            var cuota = await _context.Cuotas
                .Include(c => c.Socio)
                .Include(c => c.Tesorero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuota == null)
            {
                return NotFound();
            }

            return View(cuota);
        }

        // GET: Cuotas/Create
        public IActionResult Create()
        {
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id");
            ViewData["TesoreroId"] = new SelectList(_context.Tesoreros, "Id", "Id");
            return View();
        }

        // POST: Cuotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes,Año,Monto,Cobrada,SocioId,TesoreroId")] Cuota cuota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id", cuota.SocioId);
            ViewData["TesoreroId"] = new SelectList(_context.Tesoreros, "Id", "Id", cuota.TesoreroId);
            return View(cuota);
        }

        // GET: Cuotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cuotas == null)
            {
                return NotFound();
            }

            var cuota = await _context.Cuotas.FindAsync(id);
            if (cuota == null)
            {
                return NotFound();
            }
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id", cuota.SocioId);
            ViewData["TesoreroId"] = new SelectList(_context.Tesoreros, "Id", "Id", cuota.TesoreroId);
            return View(cuota);
        }

        // POST: Cuotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes,Año,Monto,Cobrada,SocioId,TesoreroId")] Cuota cuota)
        {
            if (id != cuota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuotaExists(cuota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Id", cuota.SocioId);
            ViewData["TesoreroId"] = new SelectList(_context.Tesoreros, "Id", "Id", cuota.TesoreroId);
            return View(cuota);
        }

        // GET: Cuotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cuotas == null)
            {
                return NotFound();
            }

            var cuota = await _context.Cuotas
                .Include(c => c.Socio)
                .Include(c => c.Tesorero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuota == null)
            {
                return NotFound();
            }

            return View(cuota);
        }

        // POST: Cuotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cuotas == null)
            {
                return Problem("Entity set 'SmartsofMarcoslescanoContext.Cuotas'  is null.");
            }
            var cuota = await _context.Cuotas.FindAsync(id);
            if (cuota != null)
            {
                _context.Cuotas.Remove(cuota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuotaExists(int id)
        {
          return _context.Cuotas.Any(e => e.Id == id);
        }
    }
}
