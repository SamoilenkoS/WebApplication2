using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BussinessLayer
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public Guid AddWeatherForecast(WeatherForecast weatherForecast)
        {
            if (weatherForecast.TemperatureC < -50)
            {
                throw new ArgumentException("Temperature is too low!");
            }

            return _weatherForecastRepository.
                AddWeatherForecast(WeatherForecastToWeatherForecastDTO(weatherForecast));
        }

        public WeatherForecast GetById(Guid id)
        {
            var dto = _weatherForecastRepository.GetById(id);
            return WeatherForecastDTOToWeatherForecast(dto);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            var dtos = _weatherForecastRepository.GetAll();

            return dtos.Select(WeatherForecastDTOToWeatherForecast);
        }

        public WeatherForecast Update(WeatherForecast weatherForecast)
        {
            var dto = _weatherForecastRepository.Update(WeatherForecastToWeatherForecastDTO(weatherForecast));

            return WeatherForecastDTOToWeatherForecast(dto);
        }

        public bool Delete(Guid id)
        {
            return _weatherForecastRepository.Delete(id);
        }

        private WeatherForecastDTO WeatherForecastToWeatherForecastDTO(WeatherForecast weatherForecast)
        {
            return new WeatherForecastDTO
            {
                Id = weatherForecast.Id,
                Date = weatherForecast.Date,
                Summary = weatherForecast.Summary,
                TemperatureC = weatherForecast.TemperatureC
            };
        }

        private WeatherForecast WeatherForecastDTOToWeatherForecast(WeatherForecastDTO weatherForecastDTO)
        {
            return new WeatherForecast
            {
                Id = weatherForecastDTO.Id,
                Date = weatherForecastDTO.Date,
                Summary = weatherForecastDTO.Summary,
                TemperatureC = weatherForecastDTO.TemperatureC,
                TemperatureF = weatherForecastDTO.TemperatureC * 2
            };
        }
    }
}
