
using System.Text.RegularExpressions;

namespace Suprema.Comum
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
