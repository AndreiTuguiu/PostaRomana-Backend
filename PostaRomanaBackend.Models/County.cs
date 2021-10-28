using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Models
{
    public class County
    {
        public County()
        {
            Locations = new HashSet<Location>();
            Cities = new HashSet<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
