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
    public class OngController : ControllerBase
    {
        private readonly IOngService _ongService;
        
        public OngController(IOngService ongService) 
        {
            _ongService = ongService;    
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_ongService.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult Obter(int id) {

            return Ok(_ongService.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Inserir(OngViewModel ong) {
            _ongService.Adicionar(ong);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(OngViewModel ongViewModel, int id )
        {
            return Ok(_ongService.Atualizar(ongViewModel, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _ongService.Remover(id);
            return Ok();
        }
    }
}
