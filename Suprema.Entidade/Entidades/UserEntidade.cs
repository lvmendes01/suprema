
using Suprema.Comum.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suprema.Entidade.Entidades
{
    [Table("Tb_Suprema_User")]
    public class UserEntidade : EntidadeBase
    {
   
    public virtual string Name { get; set; }
    public virtual string Cpf { get; set; }
    public virtual string Phone { get; set; }
    public virtual string Password { get; set; }
    public virtual string Username { get; set; }
}
}
