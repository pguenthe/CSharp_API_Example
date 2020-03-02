using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{
    public class Weather
    {
        //property name always has to align with the JSON property
        public WeatherData Data { get; set; }
        public WeatherTime Time { get; set; }
    }

    public class WeatherData
    {
        public string[] Temperature { get; set; }
        public string[] Iconlink { get; set; }
        public string[] Text { get; set; }
    }

    public class WeatherTime
    {
        public string[] StartPeriodName { get; set; }
    }
}
