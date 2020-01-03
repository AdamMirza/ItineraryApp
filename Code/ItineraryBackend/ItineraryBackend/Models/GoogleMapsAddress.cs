using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Models
{
    [JsonObject]
    public class GoogleMapsAddress
    {
        [JsonProperty]
        public List<AddressResult> Results { get; set; }
    }

    [JsonObject]
    public class AddressResult
    {
        [JsonProperty]
        public string FormattedAddress { get; set; }

        [JsonProperty]
        public Geometry Geometry { get; set; }
    }

    [JsonObject]
    public class Geometry
    {
        [JsonProperty]
        public Location Location { get; set; }
    }

    [JsonObject]
    public class Location
    {
        [JsonProperty]
        public float Lat { get; set; }
        [JsonProperty]
        public float Long { get; set; }
    }
}
