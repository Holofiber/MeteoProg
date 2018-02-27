namespace MeteoProg
{
    public class Sinoptic : IWeatherData
    {
        public int TemperatureMax { get; set; }

        public int TemperatureMin { get; set; }

        public int TemperatureCurrent { get; set; }

        public float Pressure { get; set; }

        public float Humidity { get; set; }

        public string Weather { get; set; }
    }
}
