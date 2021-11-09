using PostaRomanaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetEventList(string EventName, int? EventType, DateTime? Start, DateTime? End, int? CountryId, int? CountyId, int? CityId, CancellationToken cancellationToken);
        public Task<List<EventTypeDictionary>> GetEventTypes(CancellationToken cancellationToken);

    }
}
