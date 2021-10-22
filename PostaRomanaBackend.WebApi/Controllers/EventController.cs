using Microsoft.AspNetCore.Mvc;
using PostaRomanaBackend.PublishedLanguage.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;
        public EventController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("EventCommands")]
        public async Task<string> AddOrEditEvent(EditEvent command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return "OK";
        }
    }
}
