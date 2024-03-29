﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostaRomanaBackend.Application.Queries;

using PostaRomanaBackend.PublishedLanguage.Commands;
using PostaRomanaBackend.PublishedLanguage.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;

        public AccountController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<string> CreateAccount(MakeAccountCommand ma, CancellationToken cancellationToken)
        {
            await _mediator.Send(ma, cancellationToken);
            return "OK";
        }

        [HttpPost]
        [Route("CreateLogInSession")]
        public async Task<string> CreateSession(LogInUser USC, CancellationToken cancellationToken)
        {
            await _mediator.Send(USC, cancellationToken);
            return "OK it worked?";
        }

        

        [HttpPost]
        [Route("Token")]
        public async Task<string> UpdateTokenStatus(UpdateTokenStatusCommand tsu, CancellationToken cancellationToken)
        {
            await _mediator.Send(tsu, cancellationToken);
            return "OK";
        }


        [HttpGet]
        [Route("LogInCredentials")]
        // query: http://localhost:5000/api/Account/LogInCredentials
        // route: http://localhost:5000/api/Account/LogInCredentials/1/1961231..
        public async Task<UserQuery.ModelUser> GetUser([FromQuery] UserQuery.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        
        [HttpGet]
        [Route("CompareCredentials")]
        public async Task<bool> CompareCredentials([FromQuery] CompareUserCredentials.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("CreatePasswordRegister")]
        public async Task<string> CreateAccount(MakePasswordRecoveryRegisterCommand ma, CancellationToken cancellationToken)
        {
            await _mediator.Send(ma, cancellationToken);
            return "OK";
        }

        [HttpPost]
        [Route("ChangeUserPassword")]
        public async Task<string> ChangePassword(ChangePasswordCommand ma, CancellationToken cancellationToken)
        {
            await _mediator.Send(ma, cancellationToken);
            return "OK";
        }

        [HttpGet]
        [Route("LogTheUser")]
        public async Task<DateTime> LogInUser([FromQuery] LogInOperations.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }
    }
}