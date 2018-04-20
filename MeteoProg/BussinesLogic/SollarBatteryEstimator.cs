using System;
using BussinesLogic.Logger;

namespace BussinesLogic
{
    public class SollarBatteryEstimator
    {
        private readonly IWeatherDataProvider weatherProvider;
        private readonly ILogger logger;

        public SollarBatteryEstimator(IWeatherDataProvider weatherProvider, ILogger logger)
        {
            if (weatherProvider == null)
            {
                throw new ArgumentNullException(nameof(weatherProvider), "weatherProvider is null, can't create SollarBatteryEstimator");
            }
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "logger is null");
            }

            this.weatherProvider = weatherProvider;
            this.logger = logger;

            logger.Info($"Weather provider for SollarBatteryEstimator is - {weatherProvider}");
        }
        
        public int GetEnergyEstimationForWeak()
        {
            var weather = weatherProvider.GetWeaklyWeather();
            var temerature = 0;
            foreach (var data in weather)
            {
                temerature += data.TemperatureMax;
            }

            logger.Info($"SollarBatteryEstimator.GetEnergyEstimationForWeak: {temerature*10}");

            return temerature * 10;
        }
    }
}