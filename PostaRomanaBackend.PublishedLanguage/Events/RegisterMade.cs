using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class RegisterMade : INotification
    {
        public string Token;

        public RegisterMade(string Token)
        {
            this.Token = Token;
        }
    }
}
