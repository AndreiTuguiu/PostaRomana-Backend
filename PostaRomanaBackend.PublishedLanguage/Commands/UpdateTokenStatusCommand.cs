using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Commands
{
   public class UpdateTokenStatusCommand : IRequest
    {
        public string Token { get; set; }
    }
}
