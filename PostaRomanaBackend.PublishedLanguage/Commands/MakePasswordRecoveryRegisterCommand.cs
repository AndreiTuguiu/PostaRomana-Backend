using MediatR;
using PostaRomanaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Commands
{
    public class MakePasswordRecoveryRegisterCommand : IRequest
    {
        public string Email { get; set; }
        
    }
}
