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
        public Guid Id { get; set; }
        public string SessionName { get; set; }
        public DateTime ValidTo { get; set; }
        public int UserId { get; set; }

        public UserSessionCreated(Guid Id, DateTime ValidTo, int UserId)
        {
            this.Id = Id;
            this.ValidTo = ValidTo;
            this.UserId = UserId;
        }
    }
}
