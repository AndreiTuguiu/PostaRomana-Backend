using FluentValidation;
using MediatR;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.Models;
using PostaRomanaBackend.PublishedLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Queries
{
    public class LogInOperations
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


        public class Query : IRequest<DateTime>
        {
            public string Username { get; set; }
            public string Password { get; set; }

        }

        public class QueryHandler : IRequestHandler<Query, DateTime>
        {
            private readonly IMediator _mediator;
            private readonly PostaRomanaContext _dbContext;

            public QueryHandler(PostaRomanaContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<DateTime> Handle(Query request, CancellationToken cancellationToken)
            {
                //var person = _dbContext.Users.Where(x => x.Username == request.Username && x.Password == request.Password).FirstOrDefault();
                var person = _dbContext.Users.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);
                if (person.IsActive == false)
                {
                    throw new Exception("This account hasn't been verified yet.");
                }

                var userSession = new UserSession
                {

                    ValidTo = DateTime.Now.AddMinutes(10),
                    UserId = person.Id
                    
                };

                userSession.Id = SessionIdGenerator.GenerateSessionId();

                //await person.FirstOrDefault().UserSessions.AddAsync(userSession);

                await _dbContext.UserSessions.AddAsync(userSession);
                await _dbContext.SaveChangesAsync();


                // return Unit.Value;

                return userSession.ValidTo;
            }

        }


    }
}
