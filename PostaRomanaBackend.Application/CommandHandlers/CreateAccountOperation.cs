﻿using MediatR;
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
    public class CreateAccountOperation : IRequestHandler<MakeAccount>
    {
        private readonly IMediator _mediator;
        private readonly PostaRomanaContext _dbContext;

        public CreateAccountOperation(IMediator mediator, PostaRomanaContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(MakeAccount request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                FullName = request.FullName,
                IsActive = false,
            };

            _dbContext.Users.Add(user);
            

            AccountRegisterMade eventAccountEvent = new(request.Username, request.Password, request.Email, request.FullName, false);
            await _mediator.Publish(eventAccountEvent, cancellationToken);
            _dbContext.SaveChanges();
            return Unit.Value;

        }

       
    }
}
