﻿using System;
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
    public class AutoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autore
        public async Task<IActionResult> Index()
        {
              return _context.Autore != null ? 
                          View(await _context.Autore.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Autore'  is null.");
        }

        // GET: Autore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autore == null)
            {
                return NotFound();
            }

            var autore = await _context.Autore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // GET: Autore/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmerAutori,MbiemerAutori,Vendbanimi")] Autore autore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autore);
        }

        // GET: Autore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autore == null)
            {
                return NotFound();
            }

            var autore = await _context.Autore.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }
            return View(autore);
        }

        // POST: Autore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmerAutori,MbiemerAutori,Vendbanimi")] Autore autore)
        {
            if (id != autore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoreExists(autore.Id))
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
            return View(autore);
        }

        // GET: Autore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autore == null)
            {
                return NotFound();
            }

            var autore = await _context.Autore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // POST: Autore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autore == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Autore'  is null.");
            }
            var autore = await _context.Autore.FindAsync(id);
            if (autore != null)
            {
                _context.Autore.Remove(autore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoreExists(int id)
        {
          return (_context.Autore?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
