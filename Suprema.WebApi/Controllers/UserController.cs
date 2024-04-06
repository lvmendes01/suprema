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
        [HttpPost("Salvar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar(UserEntidade item)
        {
            var retornoChamado = servico.Adicionar(item);
            return new RetornoApi
            {
                Resultado = retornoChamado == "Ok",
                Status =true,
                Mensagem = retornoChamado == "Ok" ? "Cadastrado com Sucesso!" : retornoChamado

            };
        }


       

        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("Carregar")]
        public ActionResult<RetornoApi> Carregar(Int64 Id)
        {
            var retornoChamado = servico.Primeiro(s => s.Id == Id);
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "Item não Encontrado" : string.Empty

            };
            return retorno;
        }
    }
}
