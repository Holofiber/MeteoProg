using System;
using System.Collections.Generic;
using BussinesLogic.Logger;
using BussinesLogic.MeteoSite;

namespace BussinesLogic
{
    public class FakeWeatherProvider : IWeatherDataProvider
    {
        private readonly ILogger logger;

        public FakeWeatherProvider(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "logger is null");
            }
            this.logger = logger;
        }
        public WeatherData GetTodaysWeather()
        {
            logger.Info($"Start Fake.GetTodaysWeather");
            return new WeatherData()
            {
                Pressure = 1000,
                TemperatureMax = 20,
                Humidity = 0.8f,
                TemperatureMin = 15,
                TemperatureCurrent = 19,
                Weather = WeatherType.Sunny
            };
        }

        public List<WeatherData> GetWeaklyWeather()
        {
            logger.Info($"Start Fake.GetWeaklyWeather");
            return new List<WeatherData>()
            {
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = +20,
                    Humidity = 0.8f,
                    TemperatureMin = 15,
                    TemperatureCurrent = 19,
                    Weather = WeatherType.Sunny
                },
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = 44,
                    Humidity = 0.8f,
                    TemperatureMin =35,
                    TemperatureCurrent = 37,
                    Weather = WeatherType.Sunny
                },
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = 24,
                    Humidity = 0.8f,
                    TemperatureMin = 10,
                    TemperatureCurrent = 19,
                    Weather = WeatherType.Sunny
                },
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = 2,
                    Humidity = 0.8f,
                    TemperatureMin = 1,
                    TemperatureCurrent = 1,
                    Weather = WeatherType.Sunny
                },
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = 20,
                    Humidity = 0.8f,
                    TemperatureMin = 15,
                    TemperatureCurrent = 19,
                    Weather = WeatherType.Sunny
                },
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = 20,
                    Humidity = 0.8f,
                    TemperatureMin = 15,
                    TemperatureCurrent = 19,
                    Weather = WeatherType.Sunny
                },
                new WeatherData()
                {
                    Pressure = 1000,
                    TemperatureMax = 27,
                    Humidity = 0.8f,
                    TemperatureMin = 27,
                    TemperatureCurrent = 27,
                    Weather = WeatherType.Sunny
                },
            };
        }
    }
}