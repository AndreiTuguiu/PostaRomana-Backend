using MediatR;
using PostaRomanaBackend.Application.Helpers;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.Models;
using PostaRomanaBackend.PublishedLanguage.Commands;
using PostaRomanaBackend.PublishedLanguage.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.CommandHandlers
{
    public class ChangePasswordOperation : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public ChangePasswordOperation(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var person = _dbContext.Users.Where(x => x.Email == request.Email).FirstOrDefault();


            person.Password = request.Password;


            await _dbContext.SaveChangesAsync();

            //AccountRegisterMade eventAccountEvent = new(request.Username, request.Password, request.Email, request.FullName, false);
            //await _mediator.Publish(eventAccountEvent, cancellationToken);
            return Unit.Value;

        }


    }
}
