using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KgEtain.Models
{
    public class ConsolidatedWeather
    {
        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonProperty("weather_state_abbr")]
        public string WeatherStateAbbreviation { get; set; }

        [JsonProperty("applicable_date")]
        public string ApplicableDate { get; set; }
    }
}
