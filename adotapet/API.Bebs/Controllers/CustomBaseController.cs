using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Bebs.Controllers
{
    [ApiController]
    public abstract class CustomBaseController : ControllerBase
    {
        protected ActionResult Retorno(object result = null)
        {
            if (OperacaoValida()) 
            {
                return Ok( new
                    {
                    sucess = true,
                    data = result
                    });
            }

            return BadRequest(new
            {
                sucess = false, 
                errors = ObterErros()
            }) ;

        }

        protected bool OperacaoValida() {
            return true;
        }
        protected string ObterErros() {

            return "";
        }
    }
}
