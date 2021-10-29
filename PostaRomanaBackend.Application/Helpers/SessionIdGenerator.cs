using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application
{
    public class SessionIdGenerator
    {
        public static Guid GenerateSessionId()
        {
            return Guid.NewGuid();
        }
    }
}
