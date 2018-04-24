using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BussinesLogic;
using BussinesLogic.Loggers;


namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = LoadSettings();
            var logger = LoadLogger(settings);

            var sinoticWeatherProvider = WeatherDataProviderFactory.Create(settings.ProviderName, logger);
            var battery = new SollarBatteryEstimator(sinoticWeatherProvider, logger);

            //-------------------------------------------------------------------
            WeatherAuditor weatherAuditor = new WeatherAuditor(logger, sinoticWeatherProvider, battery);
            weatherAuditor.DoSomthing();

            System.Console.ReadKey();
        }

        public class WeatherAuditor
        {
            private readonly ILogger logger;
            private readonly IWeatherDataProvider weatherdatapprovider;
            private readonly SollarBatteryEstimator battery;


            public WeatherAuditor(ILogger logger, IWeatherDataProvider weatherdatapprovider, SollarBatteryEstimator battery)
            {
                this.logger = logger;
                this.weatherdatapprovider = weatherdatapprovider;
                this.battery = battery;
            }

            public void DoSomthing()
            {

                var today = weatherdatapprovider.GetTodaysWeather();
                var weak = weatherdatapprovider.GetWeaklyWeather();
                var poserestimat = battery.GetEnergyEstimationForWeak();

                logger.Info($"Estimate is: {poserestimat}");

                var d = DateTime.Today;

                logger.Warning($"Today weather is: T max: {today.TemperatureMax}, T min: {today.TemperatureMin}");
                
                foreach (var data in weak)
                {
                    logger.Error($"{d:d} weather is: T max: {data.TemperatureMax}, T min: {data.TemperatureMin}");
                    d = d.AddDays(1);
                }
            }
        }


        private static ILogger LoadLogger(ApplicationSettings settings)
        {
            List<ILogger> loggersList = new List<ILogger>();

            if (settings.LoggerTyppe == "Composite")
            {
                foreach (var type in settings.CompositionLoggers)
                {
                    loggersList.Add(LoggerFactory.Create(type));
                }
            }

            return LoggerFactory.Create(settings.LoggerTyppe, loggersList);
        }


        public static ApplicationSettings LoadSettings()
        {
            ApplicationSettings applicationSettings = new ApplicationSettings();

            var compositeLoggers = ConfigurationManager.AppSettings["CompositeLoggers"];
            var loggerTyps = compositeLoggers.Split(',').ToList();

            applicationSettings.CompositionLoggers = loggerTyps;
            applicationSettings.LoggerFileName = ConfigurationManager.AppSettings["LoggerFileName"];
            applicationSettings.LoggerTyppe = ConfigurationManager.AppSettings["LoggerType"];
            applicationSettings.ProviderName = ConfigurationManager.AppSettings["ProviderName"];

            return applicationSettings;
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