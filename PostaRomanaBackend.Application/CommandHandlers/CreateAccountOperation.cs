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
    public class CreateAccountOperation : IRequestHandler<MakeAccountCommand>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public CreateAccountOperation(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(MakeAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                FullName = request.FullName,
                IsActive = false,
            };

            string token = FiveCharacterCodeGenerator.GenerateToken();
            EmailSender.sendEmail(user.Email, token);

            var reg = new Register
            {
                Token = token,
                TokenStatus = "active",
                ValidTo = DateTime.Now.AddMinutes(1)
            };
            user.Registers.Add(reg);


            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            //AccountRegisterMade eventAccountEvent = new(request.Username, request.Password, request.Email, request.FullName, false);
            //await _mediator.Publish(eventAccountEvent, cancellationToken);
            return Unit.Value;

        }


    }
}
