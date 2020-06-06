using TestRestfulApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TestRestfulApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var rng = new Random();
            modelBuilder.Entity<WeatherForecast>().HasData(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow.AddDays(index),
                City = Cities[rng.Next(Cities.Length)],
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
            base.OnModelCreating(modelBuilder);
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Cities = new[]
        {
            "Pembroke", "Sliema", "St Julians", "Valletta", "Floriana", "Gzira", "Msida", "Hamrun"
        };
    }
}
