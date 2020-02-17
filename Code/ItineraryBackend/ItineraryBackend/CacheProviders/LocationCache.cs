using System;
using System.Collections.Generic;
using ItineraryBackend.Models;

namespace ItineraryBackend.CacheProviders
{
    public class LocationCache
    {
        private Dictionary<string, FullLocation> Cache { get; set; }

        public LocationCache()
        {
            this.Cache = new Dictionary<string, FullLocation>();
        }

        public bool Contains(string address)
        {
            return Cache.ContainsKey(address);
        }

        public void Add(string address, FullLocation fullLocation)
        {
            Cache.Add(address, fullLocation);
        }

        public FullLocation Get(string address)
        {
            if (Contains(address))
                return Cache[address];

            throw new MissingCacheElementException();
        }
    }
}
