using System;
using System.Collections.Generic;

#nullable disable

namespace PostaRomanaBackend.Models
{
    public partial class Event
    {
        public Event()
        {
            EventXusers = new HashSet<EventXuser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int OrganizerId { get; set; }
        public decimal? Cost { get; set; }
        public int EventTypeId { get; set; }
        public string Description { get; set; }

        public virtual Location Location { get; set; }
        public virtual EventTypeDictionary EventTypeDictionary { get; set; }
        public virtual ICollection<EventXuser> EventXusers { get; set; }
    }
}
