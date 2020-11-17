using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using adotapet.Models;

namespace adotapet.Controllers
{
    public class EntrevistaController : Controller
    {
        private readonly Context _context;

        public EntrevistaController(Context context)
        {
            _context = context;
        }

        // GET: Entrevista
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrevista.ToListAsync());
        }

        // GET: Entrevista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // GET: Entrevista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entrevista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPet,IdAdotante,Data")] Entrevista entrevista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrevista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrevista);
        }

        // GET: Entrevista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista.FindAsync(id);
            if (entrevista == null)
            {
                return NotFound();
            }
            return View(entrevista);
        }

        // POST: Entrevista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPet,IdAdotante,Data")] Entrevista entrevista)
        {
            if (id != entrevista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrevista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrevistaExists(entrevista.Id))
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
            return View(entrevista);
        }

        // GET: Entrevista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // POST: Entrevista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrevista = await _context.Entrevista.FindAsync(id);
            _context.Entrevista.Remove(entrevista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrevistaExists(int id)
        {
            return _context.Entrevista.Any(e => e.Id == id);
        }
    }
}
