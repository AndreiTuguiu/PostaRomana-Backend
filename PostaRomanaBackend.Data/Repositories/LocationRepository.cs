using Abstractions;
using PostaRomanaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly PostaRomanaContext _dbContext;
        public LocationRepository(PostaRomanaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<City>> GetCityListByCounty(int CountyId, CancellationToken cancellationToken)
        {
            var cityByCounty = _dbContext.Cities.Where(x => x.CountyId == CountyId).Select(x => new City
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();

            return await Task.FromResult(cityByCounty);
        }

        public async Task<List<Country>> GetCountryList(CancellationToken cancellationToken)
        {
            var _country = _dbContext.Countries.Select(x => new Country
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return await Task.FromResult(_country);
        }

        public async Task<List<County>> GetCountyListByCountry(int CountryId, CancellationToken cancellationToken)
        {
            var countyByCountry = _dbContext.Counties.Where(x => x.CountryId == CountryId).Select(x => new County
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return await Task.FromResult(countyByCountry);
        }
    }
}
