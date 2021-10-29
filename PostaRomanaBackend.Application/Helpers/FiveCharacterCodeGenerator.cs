using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//asta genereaza un cod alfanumeric de 5 caractere (modificabil), useful for validation emails
namespace PostaRomanaBackend.Application
{
    public class FiveCharacterCodeGenerator
    {
        public static string GenerateToken()
        {
            var builder = new StringBuilder();
            for (int i = 1; i <= 5; i++)
            {
                builder.Append(RandomCharacter());
            }
            return builder.ToString();
        }

        public static char RandomCharacter()
        {
            var values =
                new char[]{'A','B','C','D','E','F','G','H','I','J','K','L',
                'M','N','O','P','Q','R','S','T','U','V','W','X','Y',
                'Z','0','1','2','3','4','5','6','7','8','9'};
            Random rnd = new Random();
            return values[rnd.Next(0, values.Length - 1)];
        }
    }
}

