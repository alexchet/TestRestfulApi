using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestRestfulApi.Queries;
using TestRestfulApi.Response;
using TestRestfulApi.Services;

namespace TestRestfulApi.Handlers
{
    public class GetAllWeatherForecastHandler : IRequestHandler<GetAllWeatherForecastQuery, List<WeatherForecastResponse>>
    {
        private readonly IWeatherForecastService _weatherForcastService;
        private readonly IMapper _mapper;

        public GetAllWeatherForecastHandler(
            IMapper mapper,
            IWeatherForecastService weatherForcastService)
        {
            _mapper = mapper;
            _weatherForcastService = weatherForcastService;
        }

        public async Task<List<WeatherForecastResponse>> Handle(GetAllWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var result = await _weatherForcastService.GetAllAsync();
            return _mapper.Map<List<WeatherForecastResponse>>(result);
        }
    }
}
