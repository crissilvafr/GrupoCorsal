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
    public class CotizacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CotizacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cotizacion
        public async Task<IActionResult> Index()
        {
              return _context.Cotizacion != null ? 
                          View(await _context.Cotizacion.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cotizacion'  is null.");
        }

        // GET: Cotizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cotizacion == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .FirstOrDefaultAsync(m => m.id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: Cotizacion/Create
        public IActionResult Create()
        {
            
            List<SelectListItem> items = new List<SelectListItem>();
            //Productos
            List<Producto> productos = _context.Producto.ToList<Producto>();
            foreach(Producto producto in productos){
                items.Add(new SelectListItem { Text = producto.nombre, Value = producto.id.ToString() });
            }
            ViewBag.Productos = items;

            //Personas
            List<Persona> personas = _context.Persona.ToList<Persona>();
            foreach(Persona persona in personas){
                items.Add(new SelectListItem { Text = persona.nombre + " " + persona.apellido1, Value = persona.id.ToString() });
            }
            ViewBag.Personas = items;
            return View();

        }

        // POST: Cotizacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,folio,fecha_cotizacion,produto_id,monto,anio,persona_id,usuario_id,apertura_id,comision_asesor,fecha_contratacion")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cotizacion);
        }

        // GET: Cotizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cotizacion == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            return View(cotizacion);
        }

        // POST: Cotizacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,folio,fecha_cotizacion,produto_id,monto,anio,persona_id,usuario_id,apertura_id,comision_asesor,fecha_contratacion")] Cotizacion cotizacion)
        {
            if (id != cotizacion.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.id))
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
            return View(cotizacion);
        }

        // GET: Cotizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cotizacion == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .FirstOrDefaultAsync(m => m.id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cotizacion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cotizacion'  is null.");
            }
            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion != null)
            {
                _context.Cotizacion.Remove(cotizacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
          return (_context.Cotizacion?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
