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
    public class UpdateTokenStatusOperation : IRequestHandler<UpdateTokenStatusCommand>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public UpdateTokenStatusOperation(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateTokenStatusCommand request, CancellationToken cancellationToken)
        {
            Register register = _dbContext.Registers.FirstOrDefault(x => x.Token == request.Token);

            if (register == null)
            {
                throw new Exception("Token not found");
            }

            if (register.ValidTo.CompareTo(DateTime.Now) < 0)
            {
                register.TokenStatus = "expired";
            }
            else
            {
                register.TokenStatus = "used";
            }

            TokenStatusUpdated eventAccountEvent = new(request.Token);
            await _mediator.Publish(eventAccountEvent, cancellationToken);
            _dbContext.SaveChanges();
            return Unit.Value;
        }

    }
}
