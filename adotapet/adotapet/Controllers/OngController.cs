﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using Service.Models;
using Service.Interfaces;
using AutoMapper;

namespace Application.Controllers
{
    public class OngController : Controller
    {
        private readonly IOngService _ongService;
 
        public OngController(IOngService ongService)
        {
            _ongService = ongService;
        }

        // GET: Ong
        public async Task<IActionResult> Index()      
        {
            var ongs = _ongService.ObterTodos();
            return View(ongs);
        }

        // GET: Ong/Details/5
        public async Task<IActionResult> Detalhes(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var ong = _ongService.ObterPorId(id);
            if (ong == null)
            {
                return NotFound();
            }
            return View(ong);
        }

        public IActionResult Criar()
        {
            return View();
        }

        // POST: Ong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(OngViewModel ong)
        {
            if (ModelState.IsValid)
            {
                _ongService.Adicionar(ong);
                return RedirectToAction(nameof(Index));
            }
            return View(ong);
        }

        // GET: Ong/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ong = await _context.Ong.FindAsync(id);
            //if (ong == null)
            //{
            //    return NotFound();
            //}
            //return View(ong);

            return NotFound();
        }

        // POST: Ong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nome,Cnpj,Endereco,Contato")] Ong ong)
        {
            //if (id != ong.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(ong);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!OngExiste(ong.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(ong);
            return NotFound();

        }

        // GET: Ong/Delete/5
        public async Task<IActionResult> Excluir(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ong = await _context.Ong
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (ong == null)
            //{
            //    return NotFound();
            //}

            //return View(ong);
            return NotFound();
        }

        // POST: Ong/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmar(int id)
        {
            //var ong = await _context.Ong.FindAsync(id);
            //_context.Ong.Remove(ong);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return NotFound();
        }

        private bool OngExiste(int id)
        {
            //return _context.Ong.Any(e => e.Id == id);
            return false;
        }
    }
}
