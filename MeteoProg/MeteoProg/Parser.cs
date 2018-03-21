using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace MeteoProg
{
    public class Parser
    {
        public Parser(Sinoptic sinoptic)
        {
            _sinoptic = sinoptic;
        }

        public Parser()
        {
        }

        private readonly Sinoptic _sinoptic = new Sinoptic();

        public Sinoptic Pars(int dayId )
        {
            var sinopticLviv = @"https://ua.sinoptik.ua/погода-львів";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(sinopticLviv);

            var currenTemperature = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"bd1c\"]/div[1]/div[1]/div[1]/p[2]");
            var minTemerature = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id=\"bd{dayId}\"]/div[2]/div[1]/span");
            var maxTemerature = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id=\"bd{dayId}\"]/div[2]/div[2]/span");
            var press = htmlDoc.DocumentNode.SelectSingleNode($"//*[@id=\"bd{dayId}c\"]/div[1]/div[2]/table/tbody/tr[5]/td[4]");


            var pattern = @"[+-]\d{1,2}";

            _sinoptic.TemperatureCurrent = RegexData(currenTemperature.InnerText, pattern);
            _sinoptic.TemperatureMin = RegexData(minTemerature.InnerText, pattern);
            _sinoptic.TemperatureMax = RegexData(maxTemerature.InnerText, pattern);
            _sinoptic.Pressure = Convert.ToInt32(press.InnerText);
            _sinoptic.Humidity = 0;
            _sinoptic.Weather = "";
            

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