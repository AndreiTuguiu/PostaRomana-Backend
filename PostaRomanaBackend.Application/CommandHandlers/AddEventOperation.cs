using MediatR;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.Models;
using RatingSystem.PublishedLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var ev = _dbcontext.Events.FirstOrDefault(x => x.Name == request.Name && x.EventTypeId == request.EventTypeId);
            if(ev == null)
            {
                var loc = _dbcontext
                    .Locations
                    .FirstOrDefault(x => x.CountryId == request.CountryId 
                                    && x.CountyId == request.CountyId 
                                    && x.CityId == request.CityId);
                if (loc == null)
                {
                    loc = new Location()
                    {
                        CityId=request.CityId,
                        CountyId=request.CountyId,
                        CountryId=request.CountryId,
                        AddressLine=request.AddressLine
                    };
                    _dbcontext.Locations.Add(loc);
                }
                ev = new Event()
                {
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    EventTypeId = request.EventTypeId,
                    
                    Cost = request.Cost
                };  
            }

            return Unit.Value;
        }
    }
}
