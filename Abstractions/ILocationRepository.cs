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
        public Task<List<County>> GetCountyList(CancellationToken cancellationToken);
        public Task<List<City>> GetCityList(CancellationToken cancellationToken);
        public Task<List<County>> GetCountyListByCountry(int CountryId,CancellationToken cancellationToken);
        public Task<List<City>> GetCityListByCounty(int CountyId,CancellationToken cancellationToken);
        public Task<List<Country>> GetCountryById(int LocationId, CancellationToken cancellationToken);
        public Task<List<County>> GetCountyById(int LocationId, CancellationToken cancellationToken);
        public Task<List<City>> GetCityById(int LocationId, CancellationToken cancellationToken);
        public Task<List<Location>> GetAddressById(int LocationId, CancellationToken cancellationToken);

    }
}
