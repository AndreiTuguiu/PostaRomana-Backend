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
    public class UserQuery
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


        public class Query : IRequest<ModelUser>
        {  
            public string Username { get; set; }
            public string Password { get; set; }
         
        }

        public class QueryHandler : IRequestHandler<Query, ModelUser>
        {
            private readonly PostaRomanaContext _dbContext;

            public QueryHandler(PostaRomanaContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ModelUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = _dbContext.Users.Where(x => x.Username == request.Username).Where(x => x.Password == request.Password);

                var userdb = _dbContext.Users.Where(x => x.Id == person.FirstOrDefault().Id);
                
                var result = userdb.Select(x => new ModelUser
                {
                    Id=x.Id,
                    Username=x.Username,
                    Password=x.Password,
                    Email=x.Email
                    
                });

                return await Task.FromResult(result.FirstOrDefault());
            }
            
        }
        public class ModelUser
        {

            public int Id { get; set; }
            public string Username { get; set; }
           public string Password { get; set; }
            public string Email { get; set; }
            /*        public string FullName { get; set; }
                    public int? SessionId { get; set; }
                    public bool IsActive { get; set; }*/
        }

    }

       
    
}
