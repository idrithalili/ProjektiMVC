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
    public class ZhanreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZhanreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zhanre
        public async Task<IActionResult> Index()
        {
              return _context.Zhanre != null ? 
                          View(await _context.Zhanre.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Zhanre'  is null.");
        }

        // GET: Zhanre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zhanre == null)
            {
                return NotFound();
            }

            var zhanre = await _context.Zhanre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zhanre == null)
            {
                return NotFound();
            }

            return View(zhanre);
        }

        // GET: Zhanre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zhanre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zhanri,Pershkrimi")] Zhanre zhanre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zhanre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zhanre);
        }

        // GET: Zhanre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zhanre == null)
            {
                return NotFound();
            }

            var zhanre = await _context.Zhanre.FindAsync(id);
            if (zhanre == null)
            {
                return NotFound();
            }
            return View(zhanre);
        }

        // POST: Zhanre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zhanri,Pershkrimi")] Zhanre zhanre)
        {
            if (id != zhanre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zhanre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZhanreExists(zhanre.Id))
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
            return View(zhanre);
        }

        // GET: Zhanre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zhanre == null)
            {
                return NotFound();
            }

            var zhanre = await _context.Zhanre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zhanre == null)
            {
                return NotFound();
            }

            return View(zhanre);
        }

        // POST: Zhanre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zhanre == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Zhanre'  is null.");
            }
            var zhanre = await _context.Zhanre.FindAsync(id);
            if (zhanre != null)
            {
                _context.Zhanre.Remove(zhanre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZhanreExists(int id)
        {
          return (_context.Zhanre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
