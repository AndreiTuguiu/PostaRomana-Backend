using MediatR;
using Microsoft.EntityFrameworkCore;
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
        //metoda se apeleaza ori dupa 24 de ore singura din frontend, sau la apasarea butonului register mai devreme, face chestii diferite
        public async Task<Unit> Handle(UpdateTokenStatusCommand request, CancellationToken cancellationToken)
        {
            Register register = _dbContext.Registers.Include(x => x.User).FirstOrDefault(x => x.Token == request.Token);

            if (register == null)
            {
                throw new Exception("Token not found");
            }
            
            if (register.ValidTo.CompareTo(DateTime.Now) < 0) // a trecut timpul?
            {
                register.TokenStatus = "expired";
                //contu ramane inactive, cum a fost creeat
            }
            else
            {
                register.TokenStatus = "used";
                register.User.IsActive = true;
                //User.isActive devine true
            }

            TokenStatusUpdated eventAccountEvent = new(request.Token);
            await _mediator.Publish(eventAccountEvent, cancellationToken);
            _dbContext.SaveChanges();
            return Unit.Value;
        }

        public async Task<Unit> HandleRecovery(UpdateTokenStatusCommand request, CancellationToken cancellationToken)
        {
            Register register = _dbContext.Registers.Include(x => x.User).FirstOrDefault(x => x.Token == request.Token);

            if (register == null)
            {
                throw new Exception("Token not found");
            }

            if (register.ValidTo.CompareTo(DateTime.Now) < 0 && register.TokenStatus == "activeRecovery") // a trecut timpul?
            {
                register.TokenStatus = "expiredRecovery";
                //contu ramane inactive, cum a fost creeat
            }
            else
            {
                register.TokenStatus = "usedRecovery";
                register.User.IsActive = false;
                //aici fac parola null? or what happens irl, account flagged as --changeable?
            }

            TokenStatusUpdated eventAccountEvent = new(request.Token);
            await _mediator.Publish(eventAccountEvent, cancellationToken);
            _dbContext.SaveChanges();
            return Unit.Value;
        }

    }
}
