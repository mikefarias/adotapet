using System;
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

        public IActionResult Index()      
        {
            var ongs = _ongService.ObterTodos();
            return View(ongs);
        }

        public IActionResult Detalhes(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(OngViewModel ong)
        {
            if (ModelState.IsValid)
            {
                _ongService.Adicionar(ong);
                return RedirectToAction(nameof(Index));
            }
            return View(ong);
        }

        public IActionResult Editar(int id)
        {
            var ong = _ongService.ObterPorId(id);
            if (ong == null)
            {
                return NotFound();
            }
            return View(ong);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, OngViewModel ong)
        {
            if (id != ong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ongService.Atualizar(ong);
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ong);
        }

        public IActionResult Excluir(int id)
        {
           var ong =  _ongService.ObterPorId(id);

            return View(ong);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmar(int id)
        {
            _ongService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
