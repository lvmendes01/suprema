using Suprema.Entidade.Entidades;
using Suprema.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Suprema.Comum.Entidades;

namespace Suprema.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokerTableController : ControllerBase
    {

        private readonly IPokerTableService servico;

        public PokerTableController(IPokerTableService _servico)
        {
            servico = _servico;
        }
     
        
        [HttpPost("/api/poker-tables")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar(string Name)
        {
            var item = new PokerTableEntidade { DataCadastro = DateTime.Now, Name = Name };
            var retornoChamado = servico.Adicionar(item);
            return retornoChamado;
        }


        [HttpPost("/api/poker-tables/{tableId}/players")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> IncluirJogador(Int64 UserId, Int64 tableId)
        {
            var retornoChamado = servico.AdicionarJogador(UserId, tableId);
            return retornoChamado;
        }



        [HttpPost("/api/poker-tables/{tableId}/winner")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Ganhador(Int64 tableId)
        {
            var retornoChamado = servico.Simular(tableId);
            return retornoChamado;

        }

    }
}
