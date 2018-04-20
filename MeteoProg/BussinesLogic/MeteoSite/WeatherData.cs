namespace BussinesLogic.MeteoSite
{
    public class WeatherData 
    {
        public int TemperatureMax { get; set; }

        public int TemperatureMin { get; set; }

        public int TemperatureCurrent { get; set; }

        public float Pressure { get; set; }

        public float Humidity { get; set; }

        public WeatherType Weather { get; set; }

        public override string ToString()
        {
            return $"{nameof(TemperatureMax)}: {TemperatureMax}, {nameof(TemperatureMin)}: {TemperatureMin}, {nameof(TemperatureCurrent)}: {TemperatureCurrent}, {nameof(Pressure)}: {Pressure}, {nameof(Humidity)}: {Humidity}, {nameof(Weather)}: {Weather}";
        }
    }
}
