using Suprema.Comum.Entidades;
using Suprema.Entidade.Entidades;
using Suprema.Repositorio.Interfaces;
using Suprema.Servico.Interfaces;
using System.Linq.Expressions;

namespace Suprema.Servico.Servicos
{
    public class PokerTableService : IPokerTableService
    {
        private IPokerTableRepositorio PokerTableRepositorio;
        private IUserRepositorio UserRepositorio;
        public PokerTableService(IPokerTableRepositorio _PokerTableRepositorio, IUserRepositorio _UserRepositorio)
        {
            PokerTableRepositorio = _PokerTableRepositorio;
            UserRepositorio = _UserRepositorio;
        }
       
        


        public RetornoApi Adicionar(PokerTableEntidade entity)
        {
            var retorno = new RetornoApi();
            
            var poker = PokerTableRepositorio.Adicionar(entity);
            retorno.StatusSolicitacao = poker != null;
            retorno.Resultado = poker != null ? poker.Id : "Erro ao Inserir";
            return retorno;
        }

        public RetornoApi AdicionarJogador(long UserId, long TableId)
        {
            var retorno = new RetornoApi();

            //validar se mesa existe
            var mesa = PokerTableRepositorio.CarregarPoker(TableId);
            if (mesa == null)
                retorno.Mensagem = "Mesa inexistente \n";

            var jogador = UserRepositorio.Procurar(UserId);
            if (jogador == null)
                retorno.Mensagem = "Jogador inexistente \n";

            if(mesa != null && jogador != null  && mesa.Players.Count > 0  && mesa.Players.ToList().Exists(s=>s.UserEntidadeId == jogador.Id))
                retorno.Mensagem = "O mesmo usuário não possa ser inserido duas vezes na mesma mesa " + mesa.Name;

            if (mesa == null || jogador == null)
            {

                retorno.StatusSolicitacao = true;
                retorno.Resultado = false;
                return retorno;
            }
            mesa.Players.Add(new PlayerTableEntidade { DataCadastro = DateTime.Now, UserEntidade = jogador, UserEntidadeId = jogador.Id});

            return Atualizar(mesa);
        }

        public RetornoApi Atualizar(PokerTableEntidade entity)
        {

            var retorno = new RetornoApi();
            var poker = PokerTableRepositorio.Atualizar(entity);
            retorno.StatusSolicitacao = poker != null;
            retorno.Resultado = poker != null ? poker.Id : "Erro ao Atualizar";
            return retorno;
        }

        public RetornoApi Deletar(Func<PokerTableEntidade, bool> predicate)
        {
            var retorno = new RetornoApi();
            var poker = PokerTableRepositorio.Deletar(predicate);
            retorno.StatusSolicitacao = poker != null;
            retorno.Resultado = poker != null ? poker : "Erro ao Deletar";
            return retorno;

        }



        public List<PokerTableEntidade> ObterFiltros(Expression<Func<PokerTableEntidade, bool>> predicate)
        {
            return PokerTableRepositorio.ObterFiltros(predicate);
        }

        public List<PokerTableEntidade> ObterTodos(bool includes)
        {
            return PokerTableRepositorio.ObterTodos(includes);
        }

        public PokerTableEntidade Primeiro(Expression<Func<PokerTableEntidade, bool>> predicate)
        {
            return PokerTableRepositorio.Primeiro(predicate);
        }

        public PokerTableEntidade Procurar(params object[] key)
        {
            return PokerTableRepositorio.Procurar(key);
        }

        public RetornoApi Simular(long TableId)
        {
            var retorno = new RetornoApi();

            //validar se mesa existe ** DAPPER ***
            var mesa = PokerTableRepositorio.CarregarPoker(TableId);
            if (mesa == null)
            {
                retorno.Mensagem = "Mesa inexistente \n";
                retorno.StatusSolicitacao = true;
                retorno.Resultado = false;
                return retorno;
            }

            

            if (mesa.Players.Count < 2)
            {
                retorno.Mensagem = "Uma mesa precisa ter no mínimo 3 jogadores para que haja um ganhador.";
                return retorno;
            }

            // simular ganhador 
            Random random = new Random();
            int indiceGanhador = random.Next(0, mesa.Players.Count);
            var ganhador = mesa.Players[indiceGanhador];
            mesa.WinnerId = ganhador.UserEntidadeId;

            Atualizar(mesa);
            retorno.StatusSolicitacao = mesa != null;
            retorno.Resultado = "{“userName”:" + ganhador.UserEntidade.Name + ", “userId”: " + ganhador.UserEntidadeId + "}";


            return retorno;  

        }
    }
}
