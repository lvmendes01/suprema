
using Microsoft.EntityFrameworkCore;
using Suprema.Entidade.Entidades;

namespace Suprema.Comum.Infra
{
    public class ComumBDContext : DbContext
    {
        public ComumBDContext(DbContextOptions<ComumBDContext> options) : base(options)
        {

        }

        public DbSet<UserEntidade> User { get; set; }
        public DbSet<PokerTableEntidade> PokerTable { get; set; }
        
    }


}