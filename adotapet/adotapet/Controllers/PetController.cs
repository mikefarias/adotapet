using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Service.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Application.Controllers
{
    public class PetController : Controller
    {
        private readonly Context _context;

        private readonly  IWebHostEnvironment _appEnvironment;

        public PetController(Context context, IWebHostEnvironment env)
        {
            _context = context;
            _appEnvironment = env;
        }

        // GET: Pet
        public async Task<IActionResult> Index()
        {
            var context = _context.Pet.Include(p => p.Ong);
            return View(await context.ToListAsync());
        }

        // GET: Pet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.Ong)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pet/Create
        public IActionResult Create()
        {
            ViewData["IdOng"] = new SelectList(_context.Ong, "Id", "Nome");
            return View();
        }

        // POST: Pet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetViewModel model)
        {
            if (ModelState.IsValid)
            {
                string nomeUnicoArquivo = UploadedFile(model);

                Pet pet = new Pet
                {
                    Name = model.Name,
                    Abstract = model.Abstract,
                    Photo = nomeUnicoArquivo,
                    DateOfBirth = model.DateOfBirth,
                    Breed = model.Breed,
                    Weight = model.Weight,
                    IdOng = model.IdOng,
                    Ong = model.Ong
                };
                _context.Add(pet);
                    await _context .SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private string UploadedFile(PetViewModel model)
        {
            string nomeUnicoArquivo = null;

            if (model.Photo != null)
            {
                string pastaFotos = Path.Combine(_appEnvironment.WebRootPath, "img\\profile_pet");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using var fileStream = new FileStream(caminhoArquivo, FileMode.Create);
                model.Photo.CopyTo(fileStream);
            }
            return nomeUnicoArquivo;
        }
        // GET: Pet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            ViewData["IdOng"] = new SelectList(_context.Ong, "Id", "Nome", pet.IdOng);
            return View(pet);
        }

        // POST: Pet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string nomeUnicoArquivo = UploadedFile(model);

                var pet = await _context.Pet.FindAsync(id);
                pet.Name = model.Name;
                pet.Abstract = model.Abstract;
                pet.Photo = nomeUnicoArquivo;
                pet.DateOfBirth = model.DateOfBirth;
                pet.Breed = model.Breed;
                pet.Weight = model.Weight;
                pet.IdOng = model.IdOng;
                pet.Ong = model.Ong;

                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
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
            ViewData["IdOng"] = new SelectList(_context.Ong, "Id", "Nome", model.IdOng);
            return View(model);
        }

        // GET: Pet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.Ong)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.Id == id);
        }
    }
}
