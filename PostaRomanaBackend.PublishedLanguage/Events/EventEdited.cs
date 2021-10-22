using MediatR;
using System;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class EventEdited: INotification
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public decimal? Cost { get; set; }
        public int EventTypeId { get; set; }

    }
}
