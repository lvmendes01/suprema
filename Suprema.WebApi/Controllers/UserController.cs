using Suprema.Entidade.Entidades;
using Suprema.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Suprema.Comum.Entidades;

namespace Suprema.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService servico;



        public UserController(IUserService _servico)
        {
            servico = _servico;
        }
        [HttpPost("/api/users")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar(UserEntidade item)
        {
            var retornoChamado = servico.Adicionar(item);

            return retornoChamado;
        }
       


    }
}
