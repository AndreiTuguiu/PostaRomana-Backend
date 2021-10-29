using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Models
{
    public class EventTypeDictionary
    {
        public EventTypeDictionary()
        {
            Events = new HashSet<Event>();
        }
        public int Id { get; set; }
        public string EventTypeName { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
