using Suprema.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Suprema.Comum.Entidades;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Suprema.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService servico;
        private readonly IConfiguration _configuration;



        public AuthController(IUserService _servico, IConfiguration configuration)
        {
            _configuration = configuration;
            servico = _servico;
        }
        [HttpPost("/api/auth/login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> login(string username , string password )
        {
            var usuario = servico.Authenticate(username, password);

            if(usuario != null)
            {
                var secret_key = _configuration["JWT:Secret"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret_key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(                   
                    claims: new[] { new Claim(ClaimTypes.Name, username) },
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials
                );

                var tokengerado = new JwtSecurityTokenHandler().WriteToken(token);
                return new RetornoApi
                {
                    Resultado = tokengerado,
                    StatusSolicitacao = true,
                };
            }

          

            return Unauthorized();


            
        }
     
    }
}
