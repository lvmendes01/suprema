using Suprema.Comum.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suprema.Entidade.Entidades
{
    [Table("Tb_Suprema_PlayerTable")]
    public class PlayerTableEntidade : EntidadeBase
    {

        public Int64 UserEntidadeId { get; set; }

        public virtual UserEntidade UserEntidade { get; set; }
    }
}