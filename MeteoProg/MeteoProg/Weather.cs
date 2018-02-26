using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoProg
{
    class WeatherDataData : IWeatherData
    {
        public int Temperature { get; set; }

        public float Pressure { get; set; }

        public float Humidity { get; set; }

        public string Weather { get; set; }
    }
}
