using System;

namespace DataAccessLayer
{
    public class WeatherForecastDTO
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
