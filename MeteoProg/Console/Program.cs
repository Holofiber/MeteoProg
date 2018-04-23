using System;
using System.Collections.Generic;
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
            var loggerType = ConfigurationManager.AppSettings["loggerType"];
            var compositeLoggers = ConfigurationManager.AppSettings["CompositeLoggers"];
            var logfilename = ConfigurationManager.AppSettings["loggerFileName"];
            var loggerTyps = compositeLoggers.Split(',').ToList();
            List<ILogger> logList = new List<ILogger>();

            foreach (var type in loggerTyps)
            {
                if(type == "ConsoleLogger")
                    logList.Add(LoggerFactory.Create(type));
                if (type == "FileLogger")
                {
                    logList.Add(LoggerFactory.Create(type));
                }
                if (type== "DebugOutputLogger")
                {
                    logList.Add(LoggerFactory.Create(type));
                }
            }


            ILogger logger = LoggerFactory.Create(loggerType, logList);
            
            var comositLog = new CompositeLogger(logList);

            IWeatherDataProvider sinoticWeatherProvider =
                WeatherDataProviderFactory.Create(weatherProviderType, logger);

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

            System.Console.ReadKey();
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