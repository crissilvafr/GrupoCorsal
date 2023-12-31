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
    public class SexoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SexoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sexo
        public async Task<IActionResult> Index()
        {
              return _context.Sexo != null ? 
                          View(await _context.Sexo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Sexo'  is null.");
        }

        // GET: Sexo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sexo == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexo
                .FirstOrDefaultAsync(m => m.id == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // GET: Sexo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexo);
        }

        // GET: Sexo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sexo == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexo.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }
            return View(sexo);
        }

        // POST: Sexo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre")] Sexo sexo)
        {
            if (id != sexo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexoExists(sexo.id))
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
            return View(sexo);
        }

        // GET: Sexo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sexo == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexo
                .FirstOrDefaultAsync(m => m.id == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // POST: Sexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sexo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sexo'  is null.");
            }
            var sexo = await _context.Sexo.FindAsync(id);
            if (sexo != null)
            {
                _context.Sexo.Remove(sexo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexoExists(int id)
        {
          return (_context.Sexo?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
