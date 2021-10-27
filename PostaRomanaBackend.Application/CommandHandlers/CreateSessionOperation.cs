using MediatR;
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
    public class CreateSession : IRequestHandler<LogInUser>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public CreateSession(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(LogInUser request, CancellationToken cancellationToken)
        {
            var userSession = new UserSession
            {
                Id = request.Id,
                SessionName = request.SessionName,
                ValidTo = request.ValidTo

            };

            _dbContext.UserSessions.Add(userSession);


            UserSessionCreated eventCreateSession = new(request.Id, request.SessionName, userSession.ValidTo);
            await _mediator.Publish(eventCreateSession, cancellationToken);
            _dbContext.SaveChanges();
            return Unit.Value;

        }


    }
}
