using AutoMapper;
using TestRestfulApi.Models;
using TestRestfulApi.Response;
using TestRestfulApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TestRestfulApi.Requests;
using TestRestfulApi.Queries;
using MediatR;

namespace TestRestfulApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForcastService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IMapper mapper,
            IWeatherForecastService weatherForcastService,
            IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _weatherForcastService = weatherForcastService;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWeatherForecastQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _weatherForcastService.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<WeatherForecastResponse>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(WeatherForecastRequests weatherForecastRequests)
        {
            var weatherForecast = _mapper.Map<WeatherForecast>(weatherForecastRequests);
            var result = await _weatherForcastService.CreateAsync(weatherForecast);

            return CreatedAtAction("Get", new { id = result.Id }, _mapper.Map<WeatherForecastResponse>(result));
        }
    }
}
