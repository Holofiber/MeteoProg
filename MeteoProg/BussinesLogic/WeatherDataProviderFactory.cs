using System;
using BussinesLogic.Loggers;


namespace BussinesLogic
{
    public static class WeatherDataProviderFactory
    {
        public static IWeatherDataProvider Create(string weatherProviderType, ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "logger is null");
            }
            logger.Info($"Try create weather data provider: [{weatherProviderType}]");
            switch (weatherProviderType)
            {
                case "Sinoptic":
                    return new SinopticWeatherProvider(logger);
                case "Fake":
                    return new FakeWeatherProvider(logger);
                default:
                    throw new InvalidOperationException("invalid weather data provider.");
            }
        }
    }
}