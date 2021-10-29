using Abstractions;
using FluentValidation;
using MediatR;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.Data.Repositories;
using PostaRomanaBackend.Models;
using PostaRomanaBackend.PublishedLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Queries
{
    public class ListOfEvents
    {
        public class Validator : AbstractValidator<EventQueryCommand>
        {
            public Validator(PostaRomanaContext _dbContext)
            {
                //RuleFor(q => q).Must(query =>
                //{
                //    var person = query.PersonId.HasValue ?
                //    _dbContext.Persons.FirstOrDefault(x => x.Id == query.PersonId) :
                //    _dbContext.Persons.FirstOrDefault(x => x.Cnp == query.Cnp);

                //    return person != null;
                //}).WithMessage("Customer not found");
            }
        }
       

        //public class Query : IRequest<List<Event>>
        //{
        //    public int? EventTypeId { get; set; }
        //    public string EventName { get; set; }
        //    public DateTime? StartDate { get; set; }
        //    public DateTime? EndDate { get; set; }
        //    public int? CountryId { get; set; }
        //    public int? CountyId { get; set; }
        //    public int? CityId { get; set; }
        //}

        public class QueryHandler : IRequestHandler<EventQueryCommand, List<Event>>
        {
            //private readonly PostaRomanaContext _dbContext;
            private readonly IEventRepository _eventRepo;

            public QueryHandler(IEventRepository eventRepo)
            {
                _eventRepo = eventRepo;
            }

            public async Task<List<Event>> Handle(EventQueryCommand request, CancellationToken cancellationToken)
            {

                var result = _eventRepo.GetEventList(request.EventName, request.EventTypeId, request.StartDate, request.EndDate, request.CountryId, request.CountyId, request.CityId, cancellationToken).Result;
                return result;
            }
        }

        
    }
}
