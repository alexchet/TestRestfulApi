using MediatR;
using System.Collections.Generic;
using TestRestfulApi.Response;

namespace TestRestfulApi.Queries
{
    public class GetAllWeatherForecastQuery : IRequest<List<WeatherForecastResponse>>
    {
    }
}
