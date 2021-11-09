using Abstractions;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<County>> GetCountyList(CancellationToken cancellationToken)
        {
            var _county = _dbContext.Counties.Select(x => new County
            {
                Id = x.Id,
                Name = x.Name,
                CountryId= x.CountryId
            }).ToList();

            return await Task.FromResult(_county);
        }

        public async Task<List<City>> GetCityList(CancellationToken cancellationToken)
        {
            var _city = _dbContext.Cities.Select(x => new City
            {
                Id = x.Id,
                Name = x.Name,
                CountyId=x.CountyId
            }).ToList();

            return await Task.FromResult(_city);
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

        public Task<List<Country>> GetCountryById(int LocationId, CancellationToken cancellationToken)
        {
            var country = _dbContext.Events
                 .Include(x => x.Location)
                 .Include(x => x.Location.Country)
                 .Where(x => x.LocationId == LocationId).Select(x => new Country
                 {
                     Name = x.Location.Country.Name,
                     Id=x.Location.Country.Id
                 }).ToList();
            return Task.FromResult(country);
        }

        public Task<List<County>> GetCountyById(int LocationId, CancellationToken cancellationToken)
        {
            var county = _dbContext.Events
                 .Include(x => x.Location)
                 .Include(x => x.Location.County)
                 .Where(x => x.LocationId == LocationId).Select(x => new County
                 {
                     Name = x.Location.County.Name,
                     Id = x.Location.County.Id
                 }).ToList();
            return Task.FromResult(county);
        }

        public Task<List<City>> GetCityById(int LocationId, CancellationToken cancellationToken)
        {
            var city = _dbContext.Events
                 .Include(x => x.Location)
                 .Include(x => x.Location.City)
                 .Where(x => x.LocationId == LocationId).Select(x => new City
                 {
                     Name = x.Location.City.Name,
                     Id = x.Location.City.Id
                 }).ToList();
            return Task.FromResult(city);
        }

        public Task<List<Location>> GetAddressById(int LocationId, CancellationToken cancellationToken)
        {
            var adress = _dbContext.Events
                 .Include(x => x.Location)
                 .Include(x => x.Location.City)
                 .Where(x => x.LocationId == LocationId).Select(x => new Location
                 {
                     AddressLine=x.Location.AddressLine
                 }).ToList();
            return Task.FromResult(adress);
        }
    }
    
}
