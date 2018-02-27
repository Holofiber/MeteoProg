namespace MeteoProg
{
    public interface IWeatherData
    {
        int TemperatureMax { get; set; }

        int TemperatureMin { get; set; }

        int TemperatureCurrent { get; set; }

        float Pressure { get; set; }

        float Humidity { get; set; }

        string Weather { get; set; }
    }
}