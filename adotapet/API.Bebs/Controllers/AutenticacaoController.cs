using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;

namespace API.Bebs.Controllers
{
    [Route("api/autenticacao")]
    [ApiController]
    public class AutenticacaoController : CustomBaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AutenticacaoController(INotificador notificador,
                                        SignInManager<IdentityUser> signInManager,
                                        UserManager<IdentityUser> userManager
                                        ) : base(notificador) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegistrarUsuarioViewModel registrarUsuario)
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            var user = new IdentityUser
            {
                UserName = registrarUsuario.Email,
                Email = registrarUsuario.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registrarUsuario.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Retorno(registrarUsuario);
            }

            foreach (var erro in result.Errors)
                NotificarErro(erro.Description);

            return Retorno();
        }

        [HttpPost("logar")]
        public async Task<ActionResult> Login(LoginUsuarioViewModel loginUsuario) 
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Password, false, true);

            if (result.Succeeded) return Retorno(loginUsuario);
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário bloqueado por execeder número máximo de tentativas de login");
                return Retorno(loginUsuario);
            }

            NotificarErro("Usuário ou senha incorretos.");
            return Retorno(loginUsuario);
        }
    }
}
