using System;

namespace TestRestfulApi.Response
{
    public class WeatherForecastResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Summary { get; set; }
    }
}
