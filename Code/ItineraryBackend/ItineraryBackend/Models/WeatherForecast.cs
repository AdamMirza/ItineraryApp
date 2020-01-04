using System;
using System.Collections.Generic;

namespace ItineraryBackend.Models
{
    public class WeatherForecast
    {
        public WeatherForecast(DarkSkyForecast darkSkyForecast)
        {
            Forecast = new List<DailyWeather>();

            foreach (Datum d in darkSkyForecast.daily.data)
            {
                Forecast.Add(new DailyWeather(d));
            }
        }

        public List<DailyWeather> Forecast { get; set; }
    }
}
