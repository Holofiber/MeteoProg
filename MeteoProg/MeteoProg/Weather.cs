using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoProg
{
    class WeatherDataData 
    {
        public int Temperature { get; set; }

        public int TemperatureMax { get; set; }
        public int TemperatureMin { get; set; }
        public int TemperatureCurrent { get; set; }
        public float Pressure { get; set; }

        public float Humidity { get; set; }

        public string Weather { get; set; }
    }
}
