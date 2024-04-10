using Suprema.Base.Repositorio.Repositorios;
using Suprema.Comum;
using Suprema.Comum.Entidades;
using Suprema.Entidade.Entidades;
using Suprema.Repositorio.Interfaces;
using Suprema.Servico.Interfaces;
using System.Linq.Expressions;

namespace Suprema.Servico.Servicos
{
    public class UserService : IUserService
    {
        private IUserRepositorio UserRepositorio;
        private IPokerTableRepositorio TableRepositorio;
        public UserService(IUserRepositorio _UserRepositorio, IPokerTableRepositorio _TableRepositorio)
        {
            UserRepositorio = _UserRepositorio;
            TableRepositorio = _TableRepositorio;
        }

        public RetornoApi Adicionar(UserEntidade entity)
        {
            var retorno = new RetornoApi();

            if (!RegraCPF.CPF_valido(entity.Cpf))
                retorno.Mensagem = "Cpf Inválido \n";


            if(UserRepositorio.Primeiro(x=>x.Cpf == entity.Cpf) != null)
                retorno.Mensagem += "Cpf Já cadastrado \n";


            if (!RegraTelefone.Telefone_Valido(entity.Phone))
                retorno.Mensagem += "Telefone Inválido. exemplo '+55 (11) 11111-1111' \n";

            if(!string.IsNullOrEmpty(retorno.Mensagem))
            {
                return retorno;
            }

            var usuario = UserRepositorio.Adicionar(entity);

            retorno.StatusSolicitacao = usuario != null;
            retorno.Resultado = usuario != null ? usuario.Id : "Erro ao Inserir";
            return retorno;

        }

        public RetornoApi Atualizar(UserEntidade entity)
        {
            var retorno = new RetornoApi();

            var usuario = UserRepositorio.Atualizar(entity);
            retorno.StatusSolicitacao = usuario != null;
            retorno.Resultado = usuario != null ? usuario.Id : "Erro ao Atualizar";
            return retorno;
        }

        public  UserEntidade? Authenticate(string username, string password)
        {
            var login = UserRepositorio.Primeiro(s => s.Username == username && s.Password == password);
            return login ?? null;
           
        }

        public RetornoApi Deletar(Int64 Id)
        {
            var retorno = new RetornoApi();

            //carregar jogador
            var jogador = UserRepositorio.Primeiro(s => s.Id == Id);

            if(jogador == null)
            {
                retorno.Resultado = "Jogador não encontrado";
                return retorno;
            }

            // verificar se jogador nao esta em uma mesa
            var mesasConectadas = TableRepositorio.ObterMesasDoJogadorPeloId(Id);

            if(mesasConectadas != null && mesasConectadas.Count > 0)
            {
                retorno.Resultado = "Jogador Faz parte de mesa";
                return retorno;
            }


            var usuario = UserRepositorio.Deletar(s => s.Id == Id);

            retorno.StatusSolicitacao = usuario != null;
            retorno.Resultado = usuario != null ? usuario : "Erro ao Deletar";
            return retorno;

        }



        public List<UserEntidade> ObterFiltros(Expression<Func<UserEntidade, bool>> predicate)
        {
            return UserRepositorio.ObterFiltros(predicate);
        }

        public List<UserEntidade> ObterTodos(bool includes)
        {
            return UserRepositorio.ObterTodos(includes);
        }

        public UserEntidade Primeiro(Expression<Func<UserEntidade, bool>> predicate)
        {
            return UserRepositorio.Primeiro(predicate);
        }

        public UserEntidade Procurar(params object[] key)
        {
            return UserRepositorio.Procurar(key);
        }
    }
}
