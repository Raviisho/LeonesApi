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
    public class TesorerosController : Controller
    {
        private readonly SmartsofMarcoslescanoContext _context;

        public TesorerosController(SmartsofMarcoslescanoContext context)
        {
            _context = context;
        }

        // GET: Tesoreros
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tesoreros.ToListAsync());
        }

        // GET: Tesoreros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tesoreros == null)
            {
                return NotFound();
            }

            var tesorero = await _context.Tesoreros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tesorero == null)
            {
                return NotFound();
            }

            return View(tesorero);
        }

        // GET: Tesoreros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tesoreros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApellidoNombre,Período")] Tesorero tesorero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tesorero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tesorero);
        }

        // GET: Tesoreros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tesoreros == null)
            {
                return NotFound();
            }

            var tesorero = await _context.Tesoreros.FindAsync(id);
            if (tesorero == null)
            {
                return NotFound();
            }
            return View(tesorero);
        }

        // POST: Tesoreros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApellidoNombre,Período")] Tesorero tesorero)
        {
            if (id != tesorero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tesorero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesoreroExists(tesorero.Id))
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
            return View(tesorero);
        }

        // GET: Tesoreros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tesoreros == null)
            {
                return NotFound();
            }

            var tesorero = await _context.Tesoreros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tesorero == null)
            {
                return NotFound();
            }

            return View(tesorero);
        }

        // POST: Tesoreros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tesoreros == null)
            {
                return Problem("Entity set 'SmartsofMarcoslescanoContext.Tesoreros'  is null.");
            }
            var tesorero = await _context.Tesoreros.FindAsync(id);
            if (tesorero != null)
            {
                _context.Tesoreros.Remove(tesorero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesoreroExists(int id)
        {
          return _context.Tesoreros.Any(e => e.Id == id);
        }
    }
}
