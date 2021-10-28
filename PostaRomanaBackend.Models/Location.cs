using System.Collections.Generic;

#nullable disable

namespace PostaRomanaBackend.Models
{
    public partial class Location
    {
        public Location()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? CountyId { get; set; }
        public int? CityId { get; set; }
        public string AddressLine { get; set; }

        public virtual Country Country { get; set; }
        public virtual County County { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        
        

    }
}
