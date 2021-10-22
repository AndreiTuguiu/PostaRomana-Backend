using MediatR;
using System;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class EventCreated: INotification
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId{ get; set; }
        public decimal? Cost { get; set; }
        public int EventTypeId { get; set; }
        public int OrganizerId { get; set; }
    }
}