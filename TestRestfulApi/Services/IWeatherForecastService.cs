using TestRestfulApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestRestfulApi.Services
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> GetAllAsync();
        Task<WeatherForecast> GetAsync(Guid id);
        Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast);
    }
}
