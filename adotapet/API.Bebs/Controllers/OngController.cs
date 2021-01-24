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
    [Route("api/ong")]
    [ApiController]
    public class OngController : CustomBaseController
    {
        private readonly IOngService _ongService;
        
        public OngController(IOngService ongService, INotificador notificador) : base(notificador) 
        {
            _ongService = ongService;    
        }

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
        public IActionResult Atualizar(OngViewModel ongViewModel, int id) => Retorno(_ongService.Atualizar(ongViewModel, id));

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _ongService.Remover(id);
            return Retorno();
        }
    }
}
