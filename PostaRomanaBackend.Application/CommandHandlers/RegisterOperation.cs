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
    public class RegisterOperation : IRequestHandler<MakeRegister>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public RegisterOperation(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(MakeRegister request, CancellationToken cancellationToken)
        {
            var registerToken = new Register
            {
                Token = request.Token
            };

            _dbContext.Registers.Add(registerToken);

            RegisterMade eventAccountEvent = new(request.Token);
            await _mediator.Publish(eventAccountEvent, cancellationToken);
            _dbContext.SaveChanges();
            return Unit.Value;
        }

    }
}
