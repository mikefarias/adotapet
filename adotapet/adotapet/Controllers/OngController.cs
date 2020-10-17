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
    public class OngController : Controller
    {
        private readonly Context _context;

        public OngController(Context context)
        {
            _context = context;
        }

        // GET: Ong
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ong.ToListAsync());
        }

        // GET: Ong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ong = await _context.Ong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // GET: Ong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cnpj,Address,Contact")] Ong ong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ong);
        }

        // GET: Ong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ong = await _context.Ong.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }
            return View(ong);
        }

        // POST: Ong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cnpj,Address,Contact")] Ong ong)
        {
            if (id != ong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngExists(ong.Id))
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
            return View(ong);
        }

        // GET: Ong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ong = await _context.Ong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // POST: Ong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ong = await _context.Ong.FindAsync(id);
            _context.Ong.Remove(ong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngExists(int id)
        {
            return _context.Ong.Any(e => e.Id == id);
        }
    }
}
