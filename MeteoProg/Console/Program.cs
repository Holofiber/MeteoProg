using System;
using System.Configuration;
using System.Linq;
using BussinesLogic;
using BussinesLogic.Logger;


namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherProviderType = GetWeatherProviderTypeParameter(args);
            var loggerType = ConfigurationManager.AppSettings["loggerOutput"];

            ILogger logger = LoggerFactory.Create(loggerType);

            IWeatherDataProvider sinoticWeatherProvider = WeatherDataProviderFactory.Create(weatherProviderType, logger);

            SollarBatteryEstimator battery = new SollarBatteryEstimator(sinoticWeatherProvider, logger);

            //-------------------------------------------------------------------

            var today = sinoticWeatherProvider.GetTodaysWeather();
            var weak = sinoticWeatherProvider.GetWeaklyWeather();
            var poserestimat = battery.GetEnergyEstimationForWeak();

            logger.Info($"Estimate is: {poserestimat}");

            var d = DateTime.Today;

            logger.Warning($"Today weather is: T max: {today.TemperatureMax}, T min: {today.TemperatureMin}");
            logger.Info("__________________________________________________");
            foreach (var data in weak)
            {
                logger.Error($"{d:d} weather is: T max: {data.TemperatureMax}, T min: {data.TemperatureMin}");
                d = d.AddDays(1);
            }
        }

        private static string GetWeatherProviderTypeParameter(string[] args)
        {
            var weatherProviderType = ConfigurationManager.AppSettings["providerName"];

            if (args.Length > 0)
            {
                weatherProviderType = args.FirstOrDefault();
            }
            return weatherProviderType;
        }
    }
}
