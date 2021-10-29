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
    public class ListOfCountries
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


        public class Query : IRequest<List<Country>>
        {
           
        }

        public class QueryHandler : IRequestHandler<Query, List<Country>>
        {
            private readonly ILocationRepository _locationRepository;

            public QueryHandler(ILocationRepository locationRepository)
            {
                _locationRepository = locationRepository;
            }

            public async Task<List<Country>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _locationRepository.GetCountryList(cancellationToken);
                return result;
            }
        }
    }
}
