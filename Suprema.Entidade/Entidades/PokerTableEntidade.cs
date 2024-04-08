using Suprema.Comum.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suprema.Entidade.Entidades
{
    [Table("Tb_Suprema_PokerTable")]
    public class PokerTableEntidade : EntidadeBase
    {
        public virtual string Name { get; set; }


        public virtual IList<PlayerTableEntidade> Players { get; set; } = new List<PlayerTableEntidade>();
        public virtual Int64 WinnerId { get; set; }
    }
}
