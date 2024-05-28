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
    [Authorize(Roles = "Administrator")]
    public class ShtepiBotueseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShtepiBotueseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShtepiBotuese
        public async Task<IActionResult> Index()
        {
              return _context.ShtepiBotuese != null ? 
                          View(await _context.ShtepiBotuese.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ShtepiBotuese'  is null.");
        }

        // GET: ShtepiBotuese/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShtepiBotuese == null)
            {
                return NotFound();
            }

            var shtepiBotuese = await _context.ShtepiBotuese
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shtepiBotuese == null)
            {
                return NotFound();
            }

            return View(shtepiBotuese);
        }

        // GET: ShtepiBotuese/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShtepiBotuese/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShtepiaBotuese,Vendodhja")] ShtepiBotuese shtepiBotuese)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shtepiBotuese);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shtepiBotuese);
        }

        // GET: ShtepiBotuese/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShtepiBotuese == null)
            {
                return NotFound();
            }

            var shtepiBotuese = await _context.ShtepiBotuese.FindAsync(id);
            if (shtepiBotuese == null)
            {
                return NotFound();
            }
            return View(shtepiBotuese);
        }

        // POST: ShtepiBotuese/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShtepiaBotuese,Vendodhja")] ShtepiBotuese shtepiBotuese)
        {
            if (id != shtepiBotuese.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shtepiBotuese);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShtepiBotueseExists(shtepiBotuese.Id))
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
            return View(shtepiBotuese);
        }

        // GET: ShtepiBotuese/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShtepiBotuese == null)
            {
                return NotFound();
            }

            var shtepiBotuese = await _context.ShtepiBotuese
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shtepiBotuese == null)
            {
                return NotFound();
            }

            return View(shtepiBotuese);
        }

        // POST: ShtepiBotuese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShtepiBotuese == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShtepiBotuese'  is null.");
            }
            var shtepiBotuese = await _context.ShtepiBotuese.FindAsync(id);
            if (shtepiBotuese != null)
            {
                _context.ShtepiBotuese.Remove(shtepiBotuese);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShtepiBotueseExists(int id)
        {
          return (_context.ShtepiBotuese?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
