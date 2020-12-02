﻿using System;
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
using Service.Interfaces;

namespace Application.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly  IWebHostEnvironment _appEnvironment;

        public PetController(IPetService petService, IWebHostEnvironment env)
        {
            _petService = petService;    
            _appEnvironment = env;
        }

        public IActionResult Index()
        {
             return View(_petService.ObterTodos());
        }

        public IActionResult Detalhes(int id)
        {
            var pet = _petService.ObterPorId(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(PetViewModel model)
        {
            if (ModelState.IsValid)
            {
                string nomeUnicoArquivo = UploadedFile(model);
                //model.Photo = nomeUnicoArquivo;

                _petService.Adicionar(model);    
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

        public IActionResult Editar(int id)
        {
            var pet = _petService.ObterPorId(id);
            if (pet == null)
            {
                return NotFound();
            }
//            ViewData["IdOng"] = new SelectList( "Id", "Nome", pet.IdOng);
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, PetViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string nomeUnicoArquivo = UploadedFile(model);

                try
                {
                    _petService.Atualizar(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdOng"] = new SelectList(_context.Ong, "Id", "Nome", model.IdOng);
            return View(model);
        }

        public IActionResult Excluir(int id)
        {
            var pet = _petService.ObterPorId(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmacaoExcluir(int id)
        {
            _petService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
