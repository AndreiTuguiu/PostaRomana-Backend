using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class LocationCreated
    {
        public int CountryId { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public string AddressLine { get; set; }
    }
}
