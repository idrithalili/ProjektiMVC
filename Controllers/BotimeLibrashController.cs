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
    public class BotimeLibrashController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BotimeLibrashController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BotimeLibrash
        public async Task<IActionResult> Index()
        {
              return _context.BotimeLibrash != null ? 
                          View(await _context.BotimeLibrash.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BotimeLibrash'  is null.");
        }

        // GET: BotimeLibrash/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BotimeLibrash == null)
            {
                return NotFound();
            }

            var botimeLibrash = await _context.BotimeLibrash
                .FirstOrDefaultAsync(m => m.IdBotimi == id);
            if (botimeLibrash == null)
            {
                return NotFound();
            }

            return View(botimeLibrash);
        }

        // GET: BotimeLibrash/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BotimeLibrash/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBotimi,IdLibri,NumerKopjesh,Viti,Formati")] BotimeLibrash botimeLibrash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(botimeLibrash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(botimeLibrash);
        }

        // GET: BotimeLibrash/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BotimeLibrash == null)
            {
                return NotFound();
            }

            var botimeLibrash = await _context.BotimeLibrash.FindAsync(id);
            if (botimeLibrash == null)
            {
                return NotFound();
            }
            return View(botimeLibrash);
        }

        // POST: BotimeLibrash/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBotimi,IdLibri,NumerKopjesh,Viti,Formati")] BotimeLibrash botimeLibrash)
        {
            if (id != botimeLibrash.IdBotimi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(botimeLibrash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BotimeLibrashExists(botimeLibrash.IdBotimi))
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
            return View(botimeLibrash);
        }

        // GET: BotimeLibrash/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BotimeLibrash == null)
            {
                return NotFound();
            }

            var botimeLibrash = await _context.BotimeLibrash
                .FirstOrDefaultAsync(m => m.IdBotimi == id);
            if (botimeLibrash == null)
            {
                return NotFound();
            }

            return View(botimeLibrash);
        }

        // POST: BotimeLibrash/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BotimeLibrash == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BotimeLibrash'  is null.");
            }
            var botimeLibrash = await _context.BotimeLibrash.FindAsync(id);
            if (botimeLibrash != null)
            {
                _context.BotimeLibrash.Remove(botimeLibrash);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BotimeLibrashExists(int id)
        {
          return (_context.BotimeLibrash?.Any(e => e.IdBotimi == id)).GetValueOrDefault();
        }
    }
}
