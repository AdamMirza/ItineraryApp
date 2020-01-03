using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Models
{
    [JsonObject]
    public class DarkSkyForecast
    {
        [JsonProperty]
        public float Latitude { get; set; }

        [JsonProperty]
        public float Longitude { get; set; }

        [JsonProperty]
        public string Timezone { get; set; }
        
        [JsonProperty]
        public Daily Daily { get; set; }

    }

    [JsonObject]
    public class Daily {

        [JsonProperty]
        public string Icon { get; set; }

        [JsonProperty]
        public string Summary { get; set; }

        [JsonProperty]
        public List<Data> Data { get; set; }
    }

    [JsonObject]
    public class Data
    {
        [JsonProperty]
        public long Time { get; set; }

        [JsonProperty]
        public double TemperatureHigh { get; set; }

        public int TemperatureHighF => 32 + (int)(TemperatureHigh / 0.5556);

        [JsonProperty]
        public double TemperatureLow { get; set; }

        public int TemperatureLowF => 32 + (int)(TemperatureLow / 0.5556);

        [JsonProperty]
        public double PrecipProbability { get; set; }

        [JsonProperty]
        public string Icon { get; set; }

        [JsonProperty]
        public string Summary { get; set; }
    }
}
