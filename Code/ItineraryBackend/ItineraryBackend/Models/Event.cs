using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Models
{
    public class Event
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string TripId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
