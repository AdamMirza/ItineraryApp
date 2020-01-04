using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Models
{
    public class DailyWeather
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public DailyWeather(Datum d)
        {
            Date = epoch.AddSeconds(d.time);
            MaxTemperatureC = (int)Math.Floor(d.temperatureHigh);
            MinTemperatureC = (int)Math.Floor(d.temperatureLow);
            Icon = d.icon;
        }

        public DateTime Date { get; set; }
        public int MaxTemperatureC { get; set; }

        public int MaxTemperatureF => 32 + (int)(MaxTemperatureC / 0.5556);

        public int MinTemperatureC { get; set; }

        public int MinTemperatureF => 32 + (int)(MinTemperatureC / 0.5556);

        public string Icon { get; set; }
    }
}
