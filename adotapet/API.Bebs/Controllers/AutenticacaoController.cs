using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using API.Bebs.Extensoes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        private readonly AppSettings _appSettings;
        private readonly IOngService _ongService;

        public AutenticacaoController(INotificador notificador,
                                        SignInManager<IdentityUser> signInManager,
                                        UserManager<IdentityUser> userManager,
                                        IOptions<AppSettings> appSettings,
                                        IOngService ongService
                                        ) : base(notificador) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _ongService = ongService;
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

            var resultUser = await _userManager.CreateAsync(user, registrarUsuario.Password);

            if (resultUser.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var ong = registrarUsuario.Ong;
                ong.IdUsuario = user.Id ;
                ong.Usuario = user;
                var resultOng = _ongService.Adicionar(ong);
                if(!resultOng)  await _userManager.DeleteAsync(user);
                return Retorno(await GerarToken(registrarUsuario.Email));
            }

            foreach (var erro in resultUser.Errors)
                NotificarErro(erro.Description);
                
            return Retorno();
        }

        [HttpPost("logar")]
        public async Task<ActionResult> Login(LoginUsuarioViewModel loginUsuario) 
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Password, false, true);

            if (result.Succeeded) return Retorno(await GerarToken(loginUsuario.Email));
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário bloqueado por execeder número máximo de tentativas de login");
                return Retorno(loginUsuario);
            }

            NotificarErro("Usuário ou senha incorretos.");
            return Retorno(loginUsuario);
        }

        private async Task<LoginResponseViewModel> GerarToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
                claims.Add(new Claim("role", userRole));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            }) ;

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
             => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
