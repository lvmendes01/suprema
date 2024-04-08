using Suprema.Entidade.Entidades;
using Suprema.Repositorio.Interfaces;
using Suprema.Comum.Infra;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MySqlConnector;
using System.Data;
using Dapper;

namespace Suprema.Base.Repositorio.Repositorios
{
    public class PokerTableRepositorio : IPokerTableRepositorio
    {

        internal ComumBDContext Context;
        public PokerTableRepositorio(ComumBDContext context)
        {
            Context = context;
        }
        public PokerTableEntidade Adicionar(PokerTableEntidade entity)
        {

            try
            {
                Context.Set<PokerTableEntidade>().Add(entity);
                Context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string AdicionarJogador(long UserId, long TableId)
        {
            throw new NotImplementedException();
        }

        public PokerTableEntidade Atualizar(PokerTableEntidade entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PokerTableEntidade CarregarPoker(long TableId)
        {
            var stringConexao = Context.Database.GetConnectionString();

            PokerTableEntidade Mesa = new PokerTableEntidade();
            using (IDbConnection db = new MySqlConnection(stringConexao))
            {

                string sql = "SELECT * FROM bd_suprema.tb_suprema_pokertable WHERE Id =" + TableId +
                      "; SELECT * FROM bd_suprema.tb_suprema_playertable where PokerTableEntidadeId = " + TableId +
                      "; SELECT * FROM bd_suprema.tb_suprema_user; "; 

                using (var multi = db.QueryMultiple(sql))
                {
                    Mesa = multi.Read<PokerTableEntidade>().SingleOrDefault();

                    if (Mesa == null)
                        return null;
                    var jogadores = multi.Read<PlayerTableEntidade>().ToList();
                    var usuarios = multi.Read<UserEntidade>().ToList();

                    jogadores.ForEach(x => x.UserEntidade = usuarios.SingleOrDefault(s => s.Id == x.UserEntidadeId));


                    Mesa.Players = jogadores;

                }


            }
            return Mesa;
        }

        public bool Deletar(Func<PokerTableEntidade, bool> predicate)
        {
            try
            {
                Context.Set<PokerTableEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<PokerTableEntidade>().Remove(del));
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PokerTableEntidade> ObterFiltros(Expression<Func<PokerTableEntidade, bool>> predicate)
        {
            return Context.Set<PokerTableEntidade>().Where(predicate).ToList();
        }

        public List<PokerTableEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<PokerTableEntidade>().AsQueryable();
            return query.ToList();
        }

        public PokerTableEntidade Primeiro(Expression<Func<PokerTableEntidade, bool>> predicate)
        {
            return Context.Set<PokerTableEntidade>().Where(predicate).FirstOrDefault();
        }

        public PokerTableEntidade Procurar(params object[] key)
        {
            return Context.Set<PokerTableEntidade>().Find(key);
        }
    }
}
