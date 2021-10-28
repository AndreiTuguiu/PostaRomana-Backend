using Microsoft.AspNetCore.Mvc;
using PostaRomanaBackend.Application.Queries;
using PostaRomanaBackend.Models;
using PostaRomanaBackend.PublishedLanguage.Commands;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("ListOfEvents")]
        public async Task<List<Event>> GetListOfEvents([FromQuery] EventQueryCommand query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("ListOfCountries")]
        public async Task<List<Country>> GetListOfCountries([FromQuery] ListOfCountries.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("ListOfCounties")]
        public async Task<List<County>> GetListOfCounties([FromQuery] ListOfCounties.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("ListOfCities")]
        public async Task<List<City>> GetListOfCities([FromQuery] ListOfCities.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }
    }
}
