using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoCorsal.Data;
using GrupoCorsal.Models;
using Microsoft.AspNetCore.Authorization;

namespace GrupoCorsal.Controllers
{
    [Authorize]
    public class MensualidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MensualidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mensualidad
        public async Task<IActionResult> Index()
        {
              return _context.Mensualidad != null ? 
                          View(await _context.Mensualidad.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mensualidad'  is null.");
        }

        // GET: Mensualidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mensualidad == null)
            {
                return NotFound();
            }

            var mensualidad = await _context.Mensualidad
                .FirstOrDefaultAsync(m => m.id == id);
            if (mensualidad == null)
            {
                return NotFound();
            }

            return View(mensualidad);
        }

        // GET: Mensualidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mensualidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,mensualidad,cotizacion_id,monto,activo,numAutorizacion,status")] Mensualidad mensualidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensualidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensualidad);
        }

        // GET: Mensualidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mensualidad == null)
            {
                return NotFound();
            }

            var mensualidad = await _context.Mensualidad.FindAsync(id);
            if (mensualidad == null)
            {
                return NotFound();
            }
            return View(mensualidad);
        }

        // POST: Mensualidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,mensualidad,cotizacion_id,monto,activo,numAutorizacion,status")] Mensualidad mensualidad)
        {
            if (id != mensualidad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensualidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensualidadExists(mensualidad.id))
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
            return View(mensualidad);
        }

        // GET: Mensualidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mensualidad == null)
            {
                return NotFound();
            }

            var mensualidad = await _context.Mensualidad
                .FirstOrDefaultAsync(m => m.id == id);
            if (mensualidad == null)
            {
                return NotFound();
            }

            return View(mensualidad);
        }

        // POST: Mensualidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mensualidad == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mensualidad'  is null.");
            }
            var mensualidad = await _context.Mensualidad.FindAsync(id);
            if (mensualidad != null)
            {
                _context.Mensualidad.Remove(mensualidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensualidadExists(int id)
        {
          return (_context.Mensualidad?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
