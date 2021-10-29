using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class TokenStatusUpdated : INotification
    {
        public string Token { get; set; }

        public TokenStatusUpdated(string Token)
        {
            this.Token = Token;
        }
    }
}
