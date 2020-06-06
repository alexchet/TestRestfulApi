using TestRestfulApi.Data;
using TestRestfulApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestRestfulApi.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast)
        {
            weatherForecast.Id = Guid.NewGuid();
            await _context.WeatherForecast.AddAsync(weatherForecast);
            await _context.SaveChangesAsync();

            return await GetAsync(weatherForecast.Id);
        }

        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            return await _context.WeatherForecast.AsNoTracking().ToListAsync();
        }

        public async Task<WeatherForecast> GetAsync(Guid id)
        {
            return await _context.WeatherForecast.FindAsync(id);
        }
    }
}
