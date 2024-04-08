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
        public UserService(IUserRepositorio _UserRepositorio)
        {
            UserRepositorio = _UserRepositorio;
        }

        public RetornoApi Adicionar(UserEntidade entity)
        {
            var retorno = new RetornoApi();

            if (!RegraCPF.CPF_valido(entity.Cpf))
                retorno.Mensagem = "Cpf Inválido \n";


            if(UserRepositorio.Primeiro(x=>x.Cpf == entity.Cpf) != null)
                retorno.Mensagem = "Cpf Já cadastrado \n";


            if (!RegraTelefone.Telefone_Valido(entity.Phone))
                retorno.Mensagem = "Telefone Inválido. exemplo '+55 (11) 11111-1111' \n";

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

        public RetornoApi Deletar(Func<UserEntidade, bool> predicate)
        {
            var retorno = new RetornoApi();

            var usuario = UserRepositorio.Deletar(predicate)?"Delete":"Erro";
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
