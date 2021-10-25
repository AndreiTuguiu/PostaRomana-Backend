using MediatR;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.Models;
using PostaRomanaBackend.PublishedLanguage.Commands;
using PostaRomanaBackend.PublishedLanguage.Events;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.CommandHandlers
{
    public class AddEventOperation: IRequestHandler<EditEvent>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbcontext;
        public AddEventOperation(IMediator mediator, PostaRomanaContext dbcontext)
        {
            _mediator = mediator;
            _dbcontext = dbcontext;
        }
        public async Task<Unit> Handle(EditEvent request, CancellationToken cancellationToken)
        {
            var ev = _dbcontext
                .Events
                .FirstOrDefault(x => x.Name == request.Name 
                                && x.EventTypeId == request.EventTypeId);
            var loc = _dbcontext
                    .Locations
                    .FirstOrDefault(x => x.CountryId == request.CountryId
                                    && x.CountyId == request.CountyId
                                    && x.CityId == request.CityId 
                                    && x.AddressLine == request.AddressLine);
            if (loc == null)
            {
                loc = new Location()
                {
                    CityId = request.CityId,
                    CountyId = request.CountyId,
                    CountryId = request.CountryId,
                    AddressLine = request.AddressLine
                };
                _dbcontext.Locations.Add(loc);

                LocationCreated locationCreated = new()
                {
                    AddressLine = loc.AddressLine,
                    CityId = loc.CityId,
                    CountyId=loc.CountyId,
                    CountryId=loc.CountryId

                };
                await _mediator.Publish(locationCreated, cancellationToken);
                _dbcontext.SaveChanges();
            }
            if (ev == null)
            {
                
                ev = new Event()
                {
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    EventTypeId = request.EventTypeId,
                    LocationId=loc.Id,
                    Cost = request.Cost,
                    OrganizerId=request.OrganizerId,
                    Description=request.Description
                };
                _dbcontext.Events.Add(ev);

                EventCreated eventCreated = new()
                {
                    Name=ev.Name,
                    StartDate=ev.StartDate,
                    EndDate=ev.EndDate,
                    EventTypeId=ev.EventTypeId,
                    LocationId=ev.LocationId,
                    Cost=ev.Cost,
                    OrganizerId=ev.OrganizerId,
                    Description=ev.Description
                };

                await _mediator.Publish(eventCreated, cancellationToken);
            }
            else
            {
                ev.Name = request.Name;
                ev.LocationId = loc.Id;
                ev.StartDate = request.StartDate;
                ev.EndDate = request.EndDate;
                ev.EventTypeId = request.EventTypeId;
                ev.Cost = request.Cost;
                ev.Description = request.Description;

                EventEdited eventEdited = new()
                {
                    Name = ev.Name,
                    LocationId = ev.LocationId,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    EventTypeId = ev.EventTypeId,
                    Cost = ev.Cost,
                    Description=ev.Description
                };

                await _mediator.Publish(eventEdited, cancellationToken);
            }
            _dbcontext.SaveChanges();

            return Unit.Value;
        }
    }
}
