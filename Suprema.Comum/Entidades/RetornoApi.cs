using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suprema.Comum.Entidades
{
    public class RetornoApi
    {
        public bool Status { get; set; }
        public Object Resultado { get; set; }
        public string Mensagem { get; set; }
    }
}
