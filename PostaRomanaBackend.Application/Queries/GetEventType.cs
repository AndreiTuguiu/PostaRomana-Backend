using Abstractions;
using FluentValidation;
using MediatR;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Queries
{
    public class GetEventType
    {
            public class Validator : AbstractValidator<Query>
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


            public class Query : IRequest<List<EventTypeDictionary>>
            {

            }

            public class QueryHandler : IRequestHandler<Query, List<EventTypeDictionary>>
            {
                private readonly IEventRepository _eventRepository;

                public QueryHandler(IEventRepository eventRepository)
                {
                    _eventRepository = eventRepository;
                }

                public async Task<List<EventTypeDictionary>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var result = await _eventRepository.GetEventTypes(cancellationToken);
                    return result;
                }
            }
        
    }
}
