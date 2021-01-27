using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Bebs.Extensoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace API.Bebs.Controllers
{
    [Authorize]
    [Route("api/ong")]
    [ApiController]
    public class OngController : CustomBaseController
    {
        private readonly IOngService _ongService;
        
        public OngController(IOngService ongService, INotificador notificador) : base(notificador) 
        {
            _ongService = ongService;    
        }

        [ClaimsAutorize("Ong","Consulta")]
        [HttpGet]
        public IActionResult ObterOngs() => Retorno(_ongService.ObterTodos());

        [HttpGet("{id}")]
        public IActionResult Obter(int id) =>  Retorno(_ongService.ObterPorId(id));

        [HttpPost]
        public IActionResult Inserir(OngViewModel ong) 
        {
            if (!ModelState.IsValid) return Retorno(ModelState);
            _ongService.Adicionar(ong);
            return Retorno(ong);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(OngViewModel ongViewModel, int id)
        {
            if (id != ongViewModel.Id)
            {
                NotificarErro("Os ids informados não são idênticos!");
                Retorno();
            }
            if (!ModelState.IsValid) return Retorno(ongViewModel);


            return Retorno(_ongService.Atualizar(ongViewModel, id));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _ongService.Remover(id);
            return Retorno();
        }
    }
}
