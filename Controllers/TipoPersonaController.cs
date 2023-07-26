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
    public class TipoPersonaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPersonaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPersona
        public async Task<IActionResult> Index()
        {
              return _context.TipoPersona != null ? 
                          View(await _context.TipoPersona.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TipoPersona'  is null.");
        }

        // GET: TipoPersona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoPersona == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // GET: TipoPersona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPersona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre")] TipoPersona tipoPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoPersona == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona.FindAsync(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre")] TipoPersona tipoPersona)
        {
            if (id != tipoPersona.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonaExists(tipoPersona.id))
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
            return View(tipoPersona);
        }

        // GET: TipoPersona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoPersona == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // POST: TipoPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoPersona == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoPersona'  is null.");
            }
            var tipoPersona = await _context.TipoPersona.FindAsync(id);
            if (tipoPersona != null)
            {
                _context.TipoPersona.Remove(tipoPersona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonaExists(int id)
        {
          return (_context.TipoPersona?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
