using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Suprema.Comum.Infra
{
    public class RegraTelefone
    {

        public static bool Telefone_Valido(string phoneNumber)
        {
            // Expressão regular para validar um número de telefone
            string pattern = @"^\+55 \(\d{2}\) 9\d{4}-\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }


    }
}
