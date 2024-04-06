using Suprema.Entidade.Entidades;
using Suprema.Repositorio.Interfaces;
using Suprema.Comum.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Suprema.Base.Repositorio.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {

        internal ComumBDContext Context;
        public UserRepositorio(ComumBDContext context)
        {
            Context = context;
        }
        public string Adicionar(UserEntidade entity)
        {

            try
            {
                Context.Set<UserEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(UserEntidade entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return "Atualizar com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Deletar(Func<UserEntidade, bool> predicate)
        {
            try
            {
                Context.Set<UserEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<UserEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public List<UserEntidade> ObterFiltros(Expression<Func<UserEntidade, bool>> predicate)
        {
            return Context.Set<UserEntidade>().Where(predicate).ToList();
        }

        public List<UserEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<UserEntidade>().AsQueryable();
            return query.ToList();
        }

        public UserEntidade Primeiro(Expression<Func<UserEntidade, bool>> predicate)
        {
            return Context.Set<UserEntidade>().Where(predicate).FirstOrDefault();
        }

        public UserEntidade Procurar(params object[] key)
        {
            return Context.Set<UserEntidade>().Find(key);
        }
    }
}
