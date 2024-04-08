using Suprema.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Suprema.Comum.Entidades;

namespace Suprema.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService servico;



        public AuthController(IUserService _servico)
        {
            servico = _servico;
        }
        [HttpPost("/api/auth/login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> login(string username , string password )
        {
            var retornoChamado = "";
            return new RetornoApi
            {
                Resultado = retornoChamado == "Ok",
                StatusSolicitacao =true,
                Mensagem = retornoChamado == "Ok" ? "Cadastrado com Sucesso!" : retornoChamado

            };
        }
       

    }
}
