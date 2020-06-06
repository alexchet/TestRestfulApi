using AutoMapper;
using TestRestfulApi.Models;
using TestRestfulApi.Requests;
using TestRestfulApi.Response;

namespace TestRestfulApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastResponse>();
            CreateMap<WeatherForecastRequests, WeatherForecast>();
        }
    }
}
