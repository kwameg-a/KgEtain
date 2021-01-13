using Newtonsoft.Json;

namespace KgEtain.Models
{
    public class LocationSearch
    {
        [JsonProperty("woeid")]
        public int WhereOnEarthID { get; set; }
    }
}
