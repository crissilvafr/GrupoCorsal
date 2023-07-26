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
    public class MarcaProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarcaProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MarcaProducto
        public async Task<IActionResult> Index()
        {
              return _context.MarcaProducto != null ? 
                          View(await _context.MarcaProducto.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MarcaProducto'  is null.");
        }

        // GET: MarcaProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MarcaProducto == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProducto
                .FirstOrDefaultAsync(m => m.id == id);
            if (marcaProducto == null)
            {
                return NotFound();
            }

            return View(marcaProducto);
        }

        // GET: MarcaProducto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,marca_id,producto_id,version_id,activo")] MarcaProducto marcaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaProducto);
        }

        // GET: MarcaProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MarcaProducto == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProducto.FindAsync(id);
            if (marcaProducto == null)
            {
                return NotFound();
            }
            return View(marcaProducto);
        }

        // POST: MarcaProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,marca_id,producto_id,version_id,activo")] MarcaProducto marcaProducto)
        {
            if (id != marcaProducto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaProductoExists(marcaProducto.id))
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
            return View(marcaProducto);
        }

        // GET: MarcaProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MarcaProducto == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProducto
                .FirstOrDefaultAsync(m => m.id == id);
            if (marcaProducto == null)
            {
                return NotFound();
            }

            return View(marcaProducto);
        }

        // POST: MarcaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MarcaProducto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MarcaProducto'  is null.");
            }
            var marcaProducto = await _context.MarcaProducto.FindAsync(id);
            if (marcaProducto != null)
            {
                _context.MarcaProducto.Remove(marcaProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaProductoExists(int id)
        {
          return (_context.MarcaProducto?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
