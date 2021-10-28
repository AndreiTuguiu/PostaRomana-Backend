using PostaRomanaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ILocationRepository
    {
        public Task<List<Country>> GetCountryList(CancellationToken cancellationToken);
        public Task<List<County>> GetCountyListByCountry(int CountryId,CancellationToken cancellationToken);
        public Task<List<City>> GetCityListByCounty(int CountyId,CancellationToken cancellationToken);

    }
}
