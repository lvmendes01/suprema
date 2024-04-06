using Suprema.Comum.Infra;
using Suprema.Entidade;
using Suprema.Entidade.Entidades;
using Suprema.Repositorio.Interfaces;
using Suprema.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Suprema.Servico.Servicos
{
    public class UserService : IUserService
    {
        private IUserRepositorio UserRepositorio;
        public UserService(IUserRepositorio _UserRepositorio)
        {
            UserRepositorio = _UserRepositorio;
        }


        public string Adicionar(UserEntidade entity)
        {

            if (!RegraCPF.CPF_valido(entity.Cpf))
                return "Cpf Invalido";

            if (!RegraTelefone.Telefone_Valido(entity.Phone))
                return "Telefone Invalido. exemplo '+55 (21) 98765-4321'";


            return UserRepositorio.Adicionar(entity);
        }

        public string Atualizar(UserEntidade entity)
        {
            return UserRepositorio.Atualizar(entity);
        }

        public string Deletar(Func<UserEntidade, bool> predicate)
        {
            return UserRepositorio.Deletar(predicate);
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
