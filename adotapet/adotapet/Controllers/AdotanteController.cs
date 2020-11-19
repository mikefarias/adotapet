using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace adotapet.Controllers
{
    public class AdotanteController : Controller
    {
        private readonly Context _context;

        public AdotanteController(Context context)
        {
            _context = context;
        }

        // GET: Adotante
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adotante.ToListAsync());
        }

        // GET: Adotante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adotante = await _context.Adotante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adotante == null)
            {
                return NotFound();
            }

            return View(adotante);
        }

        // GET: Adotante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adotante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,RG,CPF,Endereco,Profissao,Celular")] Adotante adotante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adotante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adotante);
        }

        // GET: Adotante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adotante = await _context.Adotante.FindAsync(id);
            if (adotante == null)
            {
                return NotFound();
            }
            return View(adotante);
        }

        // POST: Adotante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,RG,CPF,Endereco,Profissao,Celular")] Adotante adotante)
        {
            if (id != adotante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adotante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdotanteExists(adotante.Id))
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
            return View(adotante);
        }

        // GET: Adotante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adotante = await _context.Adotante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adotante == null)
            {
                return NotFound();
            }

            return View(adotante);
        }

        // POST: Adotante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adotante = await _context.Adotante.FindAsync(id);
            _context.Adotante.Remove(adotante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdotanteExists(int id)
        {
            return _context.Adotante.Any(e => e.Id == id);
        }
    }
}
