using FluentValidation;
using MediatR;
using PostaRomanaBackend.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Queries
{
    public class ListOfEvents
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
       

        public class Query : IRequest<List<Model>>
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly PostaRomanaContext _dbContext;

            public QueryHandler(PostaRomanaContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                // TODO: implement logic
                return null;
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int LocationId { get; set; }
            public int OrganizerId { get; set; }
            public decimal? Cost { get; set; }
            public int EventTypeId { get; set; }
        }
    }
}
