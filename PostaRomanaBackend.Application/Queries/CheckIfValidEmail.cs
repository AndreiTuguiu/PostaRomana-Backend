using FluentValidation;
using MediatR;
using PostaRomanaBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Queries
{
    public class CheckIfValidEmail
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


        public class Query : IRequest<bool>
        {
            public string Email { get; set; }

        }

        public class QueryHandler : IRequestHandler<Query, bool>
        {
            private readonly PostaRomanaContext _dbContext;

            public QueryHandler(PostaRomanaContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = _dbContext.Users.Where(x => x.Email == request.Email);

                return await Task.FromResult(person.FirstOrDefault() != null);
            }

        }


    }


}

