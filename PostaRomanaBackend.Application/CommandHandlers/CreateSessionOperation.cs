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
            {    UserId = request.UserId,
                 ValidTo = DateTime.Now.AddMinutes(10)
            };

            userSession.Id = SessionIdGenerator.GenerateSessionId();


            
            //userSession.Id = placeholderId;
            //userSession.Id = placeholderId;
            /*userSession.UserId = placeholderId;*/

            //string SessionGuid = SessionIdGenerator.GenerateSessionId();

            UserSessionCreated eventCreateSession = new(userSession.Id, userSession.ValidTo, userSession.UserId);
            await _mediator.Publish(eventCreateSession, cancellationToken);



            await _dbContext.UserSessions.AddAsync(userSession);
            await _dbContext.SaveChangesAsync();


            return Unit.Value;

        }


    }
}
