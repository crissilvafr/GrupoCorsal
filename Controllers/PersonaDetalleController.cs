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
    public class PersonaDetalleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonaDetalleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonaDetalle
        public async Task<IActionResult> Index()
        {
              return _context.PersonaDetalle != null ? 
                          View(await _context.PersonaDetalle.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PersonaDetalle'  is null.");
        }

        // GET: PersonaDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonaDetalle == null)
            {
                return NotFound();
            }

            var personaDetalle = await _context.PersonaDetalle
                .FirstOrDefaultAsync(m => m.id == id);
            if (personaDetalle == null)
            {
                return NotFound();
            }

            return View(personaDetalle);
        }

        // GET: PersonaDetalle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,persona_id,domicilio,ingresos,referencia1,referencia2,beneficiario,telefono,correo,observaciones,fecha")] PersonaDetalle personaDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaDetalle);
        }

        // GET: PersonaDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonaDetalle == null)
            {
                return NotFound();
            }

            var personaDetalle = await _context.PersonaDetalle.FindAsync(id);
            if (personaDetalle == null)
            {
                return NotFound();
            }
            return View(personaDetalle);
        }

        // POST: PersonaDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,persona_id,domicilio,ingresos,referencia1,referencia2,beneficiario,telefono,correo,observaciones,fecha")] PersonaDetalle personaDetalle)
        {
            if (id != personaDetalle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaDetalleExists(personaDetalle.id))
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
            return View(personaDetalle);
        }

        // GET: PersonaDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonaDetalle == null)
            {
                return NotFound();
            }

            var personaDetalle = await _context.PersonaDetalle
                .FirstOrDefaultAsync(m => m.id == id);
            if (personaDetalle == null)
            {
                return NotFound();
            }

            return View(personaDetalle);
        }

        // POST: PersonaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonaDetalle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PersonaDetalle'  is null.");
            }
            var personaDetalle = await _context.PersonaDetalle.FindAsync(id);
            if (personaDetalle != null)
            {
                _context.PersonaDetalle.Remove(personaDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaDetalleExists(int id)
        {
          return (_context.PersonaDetalle?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
