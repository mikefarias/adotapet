using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Service.Models;
using AutoMapper;
using Service.Interfaces;

namespace Application.Controllers
{
    public class EntrevistaController : Controller
    {
        private readonly IEntrevistaService _entrevistaService;
        private readonly IPetService _petService;
        private readonly IAdotanteService _adotanteService;

        public EntrevistaController(IEntrevistaService entrevistaService, IPetService petService, IAdotanteService adotanteService)
        {
            _entrevistaService = entrevistaService;
            _petService = petService;
            _adotanteService = adotanteService;
        }

        public IActionResult Index()
        {
            return View(_entrevistaService.ObterTodos());
        }

        public IActionResult Detalhes(int id)
        {
            var entrevista = _entrevistaService.ObterPorId(id);
            if (entrevista == null)
            {
                return NotFound();
            }
            return View(entrevista);
        }

        public IActionResult Criar()
        {
            ViewData["IdPet"] = new SelectList(_petService.ObterTodos(), "Id", "Nome");
            ViewData["IdAdotante"] = new SelectList(_adotanteService.ObterTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(EntrevistaViewModel entrevista)
        {
            if (ModelState.IsValid)
            {
                _entrevistaService.Adicionar(entrevista);
                return RedirectToAction(nameof(Index));
            }
            return View(entrevista);
        }

        public IActionResult Editar(int id)
        {
            var entrevista = _entrevistaService.ObterPorId(id);
            if (entrevista == null)
            {
                return NotFound();
            }
            ViewData["IdPet"] = new SelectList(_petService.ObterTodos(), "Id", "Nome");
            ViewData["IdAdotante"] = new SelectList(_adotanteService.ObterTodos(), "Id", "Nome");
            return View(entrevista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, EntrevistaViewModel entrevista)
        {
            if (id != entrevista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _entrevistaService.Atualizar(entrevista);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPet"] = new SelectList(_petService.ObterTodos(), "Id", "Nome");
            ViewData["IdAdotante"] = new SelectList(_adotanteService.ObterTodos(), "Id", "Nome");

            return View(entrevista);
        }

        public IActionResult Excluir(int id)
        {

            var entrevista = _entrevistaService.ObterPorId(id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmar(int id)
        {
            _entrevistaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
