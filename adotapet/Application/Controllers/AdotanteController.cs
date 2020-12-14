using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Models;

namespace Application.Controllers
{
    public class AdotanteController : Controller
    {
        private readonly IAdotanteService _adotanteService;

        public AdotanteController(IAdotanteService adotanteService)
        {
            _adotanteService = adotanteService;
        }

        public IActionResult Index()
        {
            return View(_adotanteService.ObterTodos());
        }

        public IActionResult Detalhes(int id)
        {
            var adotante = _adotanteService.ObterPorId(id);
            if (adotante == null)
            {
                return NotFound();
            }
            return View(adotante);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(AdotanteViewModel adotante)
        {
            if (ModelState.IsValid)
            {
                _adotanteService.Adicionar(adotante);    
                return RedirectToAction(nameof(Index));
            }
            return View(adotante);
        }

        public IActionResult Editar(int id)
        {
            var adotante = _adotanteService.ObterPorId(id);
            if (adotante == null)
            {
                return NotFound();
            }
            return View(adotante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, AdotanteViewModel adotante)
        {
            if (id != adotante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _adotanteService.Atualizar(adotante);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adotante);
        }

        public IActionResult Excluir(int id)
        {
            var adotante = _adotanteService.ObterPorId(id);
            return View(adotante);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmar(int id)
        {
            _adotanteService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
