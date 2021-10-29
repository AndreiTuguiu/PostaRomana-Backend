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
    public class CreatePasswordRecoveryRegister : IRequestHandler<MakePasswordRecoveryRegisterCommand>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public CreatePasswordRecoveryRegister(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(MakePasswordRecoveryRegisterCommand request, CancellationToken cancellationToken)
        {
            var person = _dbContext.Users.Where(x => x.Email == request.Email).FirstOrDefault();

            string token = FiveCharacterCodeGenerator.GenerateToken();
            EmailSender.sendRecoveryEmail(person.Email, token);

            var register = new Register
            {
                TokenStatus = "activeRecovery",
                ValidTo = DateTime.Now.AddMinutes(10),
                UserId = person.Id,
                Token=token,
                User=person 
            };


            /*var reg = new Register
            {
                Token = token,
                TokenStatus = "active",
                ValidTo = DateTime.Now.AddMinutes(1)
            };
            user.Registers.Add(reg);


            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            EmailSender.sendEmail(user.Email, token);*/

            
            await _dbContext.Registers.AddAsync(register);


            //await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            //AccountRegisterMade eventAccountEvent = new(request.Username, request.Password, request.Email, request.FullName, false);
            //await _mediator.Publish(eventAccountEvent, cancellationToken);
            return Unit.Value;

        }


    }
}
