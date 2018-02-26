namespace MeteoProg
{
    public interface IWeatherData
    {
        int Temperature { get; set; }

        float Pressure { get; set; }

        float Humidity { get; set; }

        string Weather { get; set; }
    }
}