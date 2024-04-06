
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suprema.Entidade.Entidades;

namespace Suprema.Comum.Infra
{
    public class ComumBDContext : DbContext
    {

        public ComumBDContext(DbContextOptions<ComumBDContext> options) : base(options)
        {

        }



        public DbSet<UserEntidade> User { get; set; }
    }


}