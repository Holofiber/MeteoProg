using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using BussinesLogic.Logger;
using BussinesLogic.MeteoSite;
using HtmlAgilityPack;

namespace BussinesLogic
{
    public class SinopticWeatherProvider : IWeatherDataProvider
    {
        private readonly ILogger logger;
         
        public SinopticWeatherProvider(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "logger is null");
            }
            this.logger = logger;
        }

        public WeatherData GetTodaysWeather()
        {
            var stopwatch = Stopwatch.StartNew();
            var result =  Pars(1);
            stopwatch.Stop();
            logger.Info($"Time processing Sinoptic.GetTodaysWeather: {stopwatch.Elapsed})");
            return result;
        }

        public List<WeatherData> GetWeaklyWeather()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = Enumerable.Range(1, 7).Select(Pars).ToList();
            stopwatch.Stop();
            logger.Info($"Time processing Sinoptic.GetWeaklyWeather: {stopwatch.Elapsed})");
            return result;
        }

        private WeatherData Pars(int dayId)
        {
            var _sinoptic = new WeatherData();

            var sinopticLviv = @"https://ua.sinoptik.ua/погода-львів/10-днів";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(sinopticLviv);

            var currenTemperature = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"bd1c\"]/div[1]/div[1]/div[1]/p[2]");
            var minTemerature = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id=\"bd{dayId}\"]/div[2]/div[1]/span");
            var maxTemerature = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id=\"bd{dayId}\"]/div[2]/div[2]/span");
            var press = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id=\"bd1c\"]/div[1]/div[2]/table/tbody/tr[5]/td[3]");

            var pattern = @"[+-]\d{1,2}";

            var ct = currenTemperature.ToString();


            _sinoptic.TemperatureCurrent = RegexData(currenTemperature.InnerText, pattern);
            _sinoptic.TemperatureMin = RegexData(minTemerature.InnerText, pattern);
            _sinoptic.TemperatureMax = RegexData(maxTemerature.InnerText, pattern);
            _sinoptic.Pressure = 100;//Convert.ToInt32(press.InnerText);
            _sinoptic.Humidity = 0;
            _sinoptic.Weather = WeatherType.Cloudy;
            //*[@id="bd8"]/div[2]/div[1]/span

            //*[@id="bd2"]/div[1]
            //*[@id="bd5"]/div[1]

            return _sinoptic;
        }

        public int RegexData(string input, string pattern)
        {
            int result = 0;

            foreach (Match m in Regex.Matches(input, pattern))
            {
                result = Convert.ToInt32(m.Value);
            }

            return result;
        }


    }
}