using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekti.Data;
using Projekti.Models;

namespace Projekti.Controllers
{
    public class GjendjeLibrashController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GjendjeLibrashController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GjendjeLibrash
        public async Task<IActionResult> Index()
        {
              return _context.GjendjeLibrash != null ? 
                          View(await _context.GjendjeLibrash.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GjendjeLibrash'  is null.");
        }

        // GET: GjendjeLibrash/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GjendjeLibrash == null)
            {
                return NotFound();
            }

            var gjendjeLibrash = await _context.GjendjeLibrash
                .FirstOrDefaultAsync(m => m.IdLibri == id);
            if (gjendjeLibrash == null)
            {
                return NotFound();
            }

            return View(gjendjeLibrash);
        }

        // GET: GjendjeLibrash/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GjendjeLibrash/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibri,NumerKopjesh,Gjendje")] GjendjeLibrash gjendjeLibrash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gjendjeLibrash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gjendjeLibrash);
        }

        // GET: GjendjeLibrash/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GjendjeLibrash == null)
            {
                return NotFound();
            }

            var gjendjeLibrash = await _context.GjendjeLibrash.FindAsync(id);
            if (gjendjeLibrash == null)
            {
                return NotFound();
            }
            return View(gjendjeLibrash);
        }

        // POST: GjendjeLibrash/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibri,NumerKopjesh,Gjendje")] GjendjeLibrash gjendjeLibrash)
        {
            if (id != gjendjeLibrash.IdLibri)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gjendjeLibrash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GjendjeLibrashExists(gjendjeLibrash.IdLibri))
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
            return View(gjendjeLibrash);
        }

        // GET: GjendjeLibrash/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GjendjeLibrash == null)
            {
                return NotFound();
            }

            var gjendjeLibrash = await _context.GjendjeLibrash
                .FirstOrDefaultAsync(m => m.IdLibri == id);
            if (gjendjeLibrash == null)
            {
                return NotFound();
            }

            return View(gjendjeLibrash);
        }

        // POST: GjendjeLibrash/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GjendjeLibrash == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GjendjeLibrash'  is null.");
            }
            var gjendjeLibrash = await _context.GjendjeLibrash.FindAsync(id);
            if (gjendjeLibrash != null)
            {
                _context.GjendjeLibrash.Remove(gjendjeLibrash);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GjendjeLibrashExists(int id)
        {
          return (_context.GjendjeLibrash?.Any(e => e.IdLibri == id)).GetValueOrDefault();
        }
    }
}
