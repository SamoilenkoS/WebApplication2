using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void PostSomething(WeatherForecast weatherForecast)
        {
            weatherForecasts.Add(weatherForecast);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherForecasts;
        }
    }
}
