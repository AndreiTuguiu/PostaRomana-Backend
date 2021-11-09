using Abstractions;
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
        private readonly ILocationRepository _locationRepository;
        public EventController(MediatR.IMediator mediator,ILocationRepository locationRepository)
        {
            _mediator = mediator;
            _locationRepository = locationRepository;
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

        [HttpGet]
        [Route("GetfCounties")]
        public async Task<List<County>> GetCounties([FromQuery] GetCounties.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetfCities")]
        public async Task<List<City>> GetCities([FromQuery] GetCities.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetfTypes")]
        public async Task<List<EventTypeDictionary>> GetEventTypes([FromQuery] GetEventType.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetCountryById/{LocationId}")]
        public async Task<List<Country>> GetCountryById([FromRoute] int LocationId, CancellationToken cancellationToken)
        {
            var result = await _locationRepository.GetCountryById(LocationId, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetCountyById/{LocationId}")]
        public async Task<List<County>> GetCountyById([FromRoute] int LocationId, CancellationToken cancellationToken)
        {
            var result = await _locationRepository.GetCountyById(LocationId, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetCityById/{LocationId}")]
        public async Task<List<City>> GetCityById([FromRoute] int LocationId, CancellationToken cancellationToken)
        {
            var result = await _locationRepository.GetCityById(LocationId, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetAddressById/{LocationId}")]
        public async Task<List<Location>> GetAddressById([FromRoute] int LocationId, CancellationToken cancellationToken)
        {
            var result = await _locationRepository.GetAddressById(LocationId, cancellationToken);
            return result;
        }
    }
}
