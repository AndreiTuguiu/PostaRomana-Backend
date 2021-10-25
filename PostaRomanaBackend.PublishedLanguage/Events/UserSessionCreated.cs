using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class UserSessionCreated : INotification
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public DateTime ValidTo { get; set; }

        public UserSessionCreated(int Id, string SessionName, DateTime ValidTo)
        {
            this.Id = Id;
            this.SessionName = SessionName;
            this.ValidTo = ValidTo;
        }
    }
}
