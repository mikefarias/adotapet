using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace API.Bebs.Controllers
{
    [Route("api/pet")]
    [ApiController]
    public class PetController : CustomBaseController
    {
        private readonly IPetService _petService;
        
        public PetController(IPetService petService, INotificador notificador) : base(notificador) 
        {
            _petService = petService;    
        }

        [HttpGet]
        public IActionResult ObterPets() => Retorno(_petService.ObterTodos());

        [HttpGet("{id}")]
        public IActionResult Obter(int id) =>  Retorno(_petService.ObterPorId(id));

        [HttpPost]
        public IActionResult Inserir(PetViewModel pet) 
        {
            if (!ModelState.IsValid) return Retorno(ModelState);
            _petService.Adicionar(pet);
            return Retorno(pet);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(PetViewModel petViewModel, int id) => Retorno(_petService.Atualizar(petViewModel, id));

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _petService.Remover(id);
            return Retorno();
        }
    }
}
