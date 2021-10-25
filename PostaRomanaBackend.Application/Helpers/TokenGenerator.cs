using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Helpers
{
    public class TokenGenerator
    {
        public static string generateToken()
        {
            // asta o sa aiba 36 caractere
            return Guid.NewGuid().ToString();
        }
    }
}
