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
    public class VersionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VersionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Version
        public async Task<IActionResult> Index()
        {
              return _context.Version != null ? 
                          View(await _context.Version.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Version'  is null.");
        }

        // GET: Version/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Version == null)
            {
                return NotFound();
            }

            var version = await _context.Version
                .FirstOrDefaultAsync(m => m.id == id);
            if (version == null)
            {
                return NotFound();
            }

            return View(version);
        }

        // GET: Version/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Version/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre")] GrupoCorsal.Models.Version version)
        {
            if (ModelState.IsValid)
            {
                _context.Add(version);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(version);
        }

        // GET: Version/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Version == null)
            {
                return NotFound();
            }

            var version = await _context.Version.FindAsync(id);
            if (version == null)
            {
                return NotFound();
            }
            return View(version);
        }

        // POST: Version/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre")] GrupoCorsal.Models.Version version)
        {
            if (id != version.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(version);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersionExists(version.id))
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
            return View(version);
        }

        // GET: Version/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Version == null)
            {
                return NotFound();
            }

            var version = await _context.Version
                .FirstOrDefaultAsync(m => m.id == id);
            if (version == null)
            {
                return NotFound();
            }

            return View(version);
        }

        // POST: Version/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Version == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Version'  is null.");
            }
            var version = await _context.Version.FindAsync(id);
            if (version != null)
            {
                _context.Version.Remove(version);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersionExists(int id)
        {
          return (_context.Version?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
