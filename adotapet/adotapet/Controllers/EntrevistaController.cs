using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entidades;
using Domain.Modelos;

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
            var context = _context.Entrevista.
                Include(p => p.Pet).
                Include(p => p.Adotante);
             return View(await context.ToListAsync());
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
            ViewData["IdPet"] = new SelectList(_context.Pet, "Id", "Name");
            ViewData["IdAdotante"] = new SelectList(_context.Adotante, "Id", "Nome");
            return View();
        }

        // POST: Entrevista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntrevistaModelView model)
        {
            if (ModelState.IsValid)
            {
                Entrevista entrevista = new Entrevista
                {
                    Pet = model.Pet,
                    IdPet = model.IdPet,
                    Adotante = model.Adotante,
                    IdAdotante = model.IdAdotante,
                    Data = model.Data
                };
                _context.Add(entrevista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Entrevista/Edit/5
        public async Task<IActionResult> Edit(int? id, EntrevistaModelView model)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var entrevista = await _context.Entrevista.FindAsync(id);
                entrevista.IdPet = model.IdPet;
                entrevista.Pet = model.Pet;
                entrevista.IdAdotante = model.IdAdotante;
                entrevista.Adotante = model.Adotante;
                entrevista.Data = model.Data;

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


            ViewData["IdPet"] = new SelectList(_context.Pet, "IdPet", "Name", model.IdPet);
            ViewData["IdAdotante"] = new SelectList(_context.Adotante, "IdAdotante", "Nome", model.IdAdotante);
            return View(model);
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
