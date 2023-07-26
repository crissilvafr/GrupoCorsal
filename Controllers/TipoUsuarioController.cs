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
    public class TipoUsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoUsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoUsuario
        public async Task<IActionResult> Index()
        {
              return _context.TipoUsuario != null ? 
                          View(await _context.TipoUsuario.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TipoUsuario'  is null.");
        }

        // GET: TipoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoUsuario == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // GET: TipoUsuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoUsuario == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre")] TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUsuarioExists(tipoUsuario.id))
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
            return View(tipoUsuario);
        }

        // GET: TipoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoUsuario == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // POST: TipoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoUsuario == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoUsuario'  is null.");
            }
            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario != null)
            {
                _context.TipoUsuario.Remove(tipoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUsuarioExists(int id)
        {
          return (_context.TipoUsuario?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
