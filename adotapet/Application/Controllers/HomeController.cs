using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Service.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Application.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPetService _petService;

        public HomeController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index(string palavraChave)
        {
            if (palavraChave != null) {
                return View(_petService.ObterPetsPorPalavraChave(palavraChave));
            }
            return View( _petService.ObterTodos());
        }

        public IActionResult Ong()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
