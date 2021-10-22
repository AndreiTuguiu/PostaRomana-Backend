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
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public AccountRegisterMade(string Username, string Password, string Email, string FullName, bool IsActive)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.FullName = FullName;
            this.IsActive = IsActive;
        }
    }
}
