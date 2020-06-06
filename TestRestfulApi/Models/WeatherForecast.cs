using System;

namespace TestRestfulApi.Models
{
    public class WeatherForecast
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Summary { get; set; }
    }
}
