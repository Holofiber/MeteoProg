using System.Collections.Generic;
using BussinesLogic.MeteoSite;

namespace BussinesLogic
{
    public interface IWeatherDataProvider
    {
        WeatherData GetTodaysWeather();

        List<WeatherData> GetWeaklyWeather();
    }
}