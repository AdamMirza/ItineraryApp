using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Providers
{
    public interface IWeatherForecastApi
    {
        public Task<DarkSkyWeatherApi> GetWeatherForecast(string address);
    }
}
