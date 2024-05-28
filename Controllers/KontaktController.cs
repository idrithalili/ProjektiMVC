using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekti.Data;
using Projekti.Models;
using Microsoft.AspNetCore.Authorization;

namespace Projekti.Controllers
{
    [Authorize(Roles = "User")]
    public class KontaktController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KontaktController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kontakt
        public async Task<IActionResult> Index()
        {
              return _context.Kontakte != null ? 
                          View(await _context.Kontakte.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Kontakte'  is null.");
        }

        public IActionResult Mesazh()
        {
            return View();
        }

        // GET: Kontakt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kontakte == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }

        // GET: Kontakt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kontakt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emer,Mbiemer,Mosha,Gjinia,Email,NumerTelefoni,Mesazhi")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mesazh));
            }
            return View(kontakt);
        }

        // GET: Kontakt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kontakte == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakte.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }
            return View(kontakt);
        }

        // POST: Kontakt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Emer,Mbiemer,Mosha,Gjinia,Email,NumerTelefoni,Mesazhi")] Kontakt kontakt)
        {
            if (id != kontakt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontakt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontaktExists(kontakt.Id))
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
            return View(kontakt);
        }

        // GET: Kontakt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kontakte == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }

        // POST: Kontakt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Kontakte == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kontakte'  is null.");
            }
            var kontakt = await _context.Kontakte.FindAsync(id);
            if (kontakt != null)
            {
                _context.Kontakte.Remove(kontakt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontaktExists(int? id)
        {
          return (_context.Kontakte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
