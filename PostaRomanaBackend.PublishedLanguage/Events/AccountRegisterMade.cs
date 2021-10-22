using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class AccountRegisterMade : INotification
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AccountRegisterMade(string Username, string Password, string Email)
        {
            Username = Username;
            Password = Password;
            Email = Email;
        }
    }
}
