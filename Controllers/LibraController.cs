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
    
    public class LibraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibraController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Kerkim(string searchTerm)
        {
            string searchTermLower = searchTerm.ToLower();

            var searchResults = _context.Libra.Where(l => l.Titulli.ToLower().StartsWith(searchTermLower)).ToList();

            return View("Kerkim", searchResults);
        }

        // GET: Libra
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Libra.Include(l => l.Autore).Include(l => l.ShtepiBotuese).Include(l => l.Zhanri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Libra/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libra == null)
            {
                return NotFound();
            }

            var libra = await _context.Libra
                .Include(l => l.Autore)
                .Include(l => l.ShtepiBotuese)
                .Include(l => l.Zhanri)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libra == null)
            {
                return NotFound();
            }

            return View(libra);
        }

        // GET: Libra/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Autori");
            ViewData["ShtepiBotueseId"] = new SelectList(_context.ShtepiBotuese, "Id", "ShtepiaBotuese");
            ViewData["ZhanriId"] = new SelectList(_context.Zhanre, "Id", "Zhanri");
            return View();
        }

        // POST: Libra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Titulli,AutoreId,ZhanriId,Viti,ShtepiBotueseId,Cmimi,Pershkrimi")] Libra libra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Autori");
            ViewData["ShtepiBotueseId"] = new SelectList(_context.ShtepiBotuese, "Id", "ShtepiaBotuese", libra.ShtepiBotueseId);
            ViewData["ZhanriId"] = new SelectList(_context.Zhanre, "Id", "Zhanri", libra.ZhanriId);
            return View(libra);
        }

        // GET: Libra/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libra == null)
            {
                return NotFound();
            }

            var libra = await _context.Libra.FindAsync(id);
            if (libra == null)
            {
                return NotFound();
            }
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Autori", libra.AutoreId);
            ViewData["ShtepiBotueseId"] = new SelectList(_context.ShtepiBotuese, "Id", "ShtepiaBotuese", libra.ShtepiBotueseId);
            ViewData["ZhanriId"] = new SelectList(_context.Zhanre, "Id", "Zhanri", libra.ZhanriId);
            return View(libra);
        }

        // POST: Libra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Titulli,AutoreId,ZhanriId,Viti,ShtepiBotueseId,Cmimi,Pershkrimi")] Libra libra)
        {
            if (id != libra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libra);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraExists(libra.Id))
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
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Autori", libra.AutoreId);
            ViewData["ShtepiBotueseId"] = new SelectList(_context.ShtepiBotuese, "Id", "ShtepiaBotuese", libra.ShtepiBotueseId);
            ViewData["ZhanriId"] = new SelectList(_context.Zhanre, "Id", "Zhanri", libra.ZhanriId);
            return View(libra);
        }

        // GET: Libra/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libra == null)
            {
                return NotFound();
            }

            var libra = await _context.Libra
                .Include(l => l.Autore)
                .Include(l => l.ShtepiBotuese)
                .Include(l => l.Zhanri)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libra == null)
            {
                return NotFound();
            }

            return View(libra);
        }

        // POST: Libra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Libra == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Libra'  is null.");
            }
            var libra = await _context.Libra.FindAsync(id);
            if (libra != null)
            {
                _context.Libra.Remove(libra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraExists(int? id)
        {
          return (_context.Libra?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        

    }
}
