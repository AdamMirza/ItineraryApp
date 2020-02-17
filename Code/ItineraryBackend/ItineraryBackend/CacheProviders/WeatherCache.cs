using System;
using System.Collections;
using System.Collections.Generic;
using ItineraryBackend.Models;

namespace ItineraryBackend.CacheProviders
{
    public class WeatherCache
    {
        private Dictionary<string, WeatherForecast> Cache { get; set; }

        public WeatherCache()
        {
            this.Cache = new Dictionary<string, WeatherForecast>();
        }

        public bool Contains(string fullLocation)
        {
            return Cache.ContainsKey(fullLocation);
        }

        public void Add(string location, WeatherForecast weatherForecast)
        {
            Cache.Add(location, weatherForecast);
        }

        public void Add(FullLocation fullLocation, WeatherForecast weatherForecast)
        {
            Cache.Add(fullLocation.ToString(), weatherForecast);
        }

        public WeatherForecast Get(FullLocation fullLocation)
        {
            if (Contains(fullLocation.ToString()))
                return Cache[fullLocation.ToString()];

            throw new MissingCacheElementException();
        }

        public WeatherForecast Get(string fullLocation)
        {
            if (Contains(fullLocation))
            {
                return Cache[fullLocation];
            }

            throw new MissingCacheElementException();
        }
    }
}
