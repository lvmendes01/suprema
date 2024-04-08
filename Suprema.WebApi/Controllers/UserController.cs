using Suprema.Entidade.Entidades;
using Suprema.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Suprema.Comum.Entidades;
using Microsoft.AspNetCore.Authorization;

namespace Suprema.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService servico;



        public UserController(IUserService _servico)
        {
            servico = _servico;
        }
      
        [HttpPost("/users")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public ActionResult<RetornoApi> Salvar(UserEntidade item)
        {
            var retornoChamado = servico.Adicionar(item);

            return retornoChamado;
        }
       


    }
}
