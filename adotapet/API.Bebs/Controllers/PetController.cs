using System;
using System.Collections.Generic;
using System.IO;
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

            var foto = Guid.NewGuid() + "_" + pet.Foto;
            if (!UploadArquivo(pet.ArquivoFoto, foto))
            {
                return Retorno(pet);
            }
            _petService.Adicionar(pet);
            return Retorno(pet);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(PetViewModel petViewModel, int id)
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            if (petViewModel.ArquivoFoto!= null)
            {
                var foto = Guid.NewGuid() + "_" + petViewModel.Foto;
                if (!UploadArquivo(petViewModel.ArquivoFoto, foto))
                {
                    return Retorno(ModelState);
                }
            }
            return Retorno(_petService.Atualizar(petViewModel, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _petService.Remover(id);
            return Retorno();
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/pets", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
