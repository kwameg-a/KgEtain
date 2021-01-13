using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KgEtain.Models
{
    public class ApiResponse
    {
        [JsonProperty("consolidated_weather")]
        public IList<ConsolidatedWeather> ConsolidatedWeatherList { get; set; }

        [JsonProperty("woeid")]
        public int WhereOnEarthID { get; set; }
    }    
}
