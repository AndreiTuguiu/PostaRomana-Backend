using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application
{
    public class SessionIdGenerator
    {
        public string GenerateSessionId()
        {
            var sessionId = new Guid().ToString();
            return sessionId;
        }
    }
}
