using Microsoft.AspNetCore.Mvc;
using PostaRomanaBackend.Application.Queries;
using PostaRomanaBackend.Models;
using PostaRomanaBackend.PublishedLanguage.Commands;
using PostaRomanaBackend.PublishedLanguage.Events;
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
        public async Task<string> CreateAccount(AccountRegisterMade command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return "OK";
        }
        [HttpPost]
        [Route("LogIn")]
        public async Task<string> CreateSession(UserSessionCreated USC, CancellationToken cancellationToken)
        {
            await _mediator.Send(USC, cancellationToken);
            return "OK";
        }

        
    }
}