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
    public class EventRepositories : IEventRepository
    {
        private readonly PostaRomanaContext _dbContext;
        public EventRepositories(PostaRomanaContext dbContenxt)
        {
            _dbContext = dbContenxt;
        }
        public async Task<List<Event>> GetEventList(string EventName, int? EventType, DateTime? Start, DateTime? End, int? CountryId, int? CountyId, int? CityId, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Events.AsQueryable();

            if (Start != null && Start != DateTime.MinValue)
            {
                query = query.Where(x => x.StartDate == Start);
            }

            if (End != null && End != DateTime.MinValue)
            {
                query = query.Where(x => x.EndDate == End);
            }

            if (!string.IsNullOrEmpty(EventName))
            {
                query = query.Where(x => x.Name.Contains(EventName));
            }

            if (EventType != null)
            {
                query = query.Where(x => x.EventTypeId == EventType);
            }

            var loc = _dbContext.Locations.AsQueryable();

            if (CountryId != null)
            {
                loc = loc.Where(x => x.CountryId == CountryId);
                query = query.Where(x => loc.Any(y => y.Id == x.LocationId));
            }

            if (CountyId != null)
            {
                loc = loc.Where(x => x.CountyId == CountyId);
                query = query.Where(x => loc.Any(y => y.Id == x.LocationId));
            }

            if (CityId != null)
            {
                loc = loc.Where(x => x.CityId == CityId);
                query = query.Where(x => loc.Any(y => y.Id == x.LocationId));
            }

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<List<EventTypeDictionary>> GetEventTypes(CancellationToken cancellationToken)
        {
            var _types = _dbContext.EventTypeDictionaries.Select(x => new EventTypeDictionary
            {
                Id=x.Id,
                EventTypeName=x.EventTypeName
            }).ToList();

            return await Task.FromResult(_types);
        }
    }
}
