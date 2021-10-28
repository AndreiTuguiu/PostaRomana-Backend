using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Models
{
    public class Country
    {
        public Country()
        {
            Locations = new HashSet<Location>();
            Counties = new HashSet<County>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<County> Counties { get; set; }
    }
}
