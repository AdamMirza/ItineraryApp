using ItineraryBackend.CacheProviders;
using ItineraryBackend.Controllers;
using ItineraryBackend.Models;
using ItineraryBackend.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ItineraryBackend.Providers
{
    public class DarkSkyWeatherApi
    {
        private readonly IConfiguration config;
        private readonly IHttpClientFactory clientFactory;
        private ILogger<WeatherForecastController> logger;
        private WeatherCache weatherCache;
        private LocationCache locationCache;

        public DarkSkyWeatherApi(IConfiguration config,
                                 IHttpClientFactory clientFactory,
                                 ILogger<WeatherForecastController> logger,
                                 WeatherCache weatherCache,
                                 LocationCache locationCache)
        {
            this.config = config;
            this.clientFactory = clientFactory;
            this.logger = logger;
            this.weatherCache = weatherCache;
            this.locationCache = locationCache;
        }

        public async Task<WeatherForecast> GetWeatherForecast(string address)
        {
            if (this.locationCache.Contains(address))
            {
                try
                {
                    FullLocation fullLocation = this.locationCache.Get(address);

                    if (this.weatherCache.Contains(fullLocation.ToString()))
                    {
                        return this.weatherCache.Get(fullLocation);
                    }
                }
                catch (MissingCacheElementException mEx)
                {
                    logger.LogError(mEx.ToString());
                }
            }

            var darkSkyApiKey = config[ItineraryConstants.AzureConstants.DarkSkyKeyVault];
            var googleMapsApiKey = config[ItineraryConstants.AzureConstants.GoogleMapsKeyVault];

            Result addressCoordinates = HttpRequestHelper.GetLatLong(address, googleMapsApiKey, clientFactory).Result.results[0];

            this.locationCache.Add(address, new FullLocation()
            {
                Name = address,
                Lat = addressCoordinates.geometry.location.lat,
                Long = addressCoordinates.geometry.location.lng,
                Date = DateTime.Today
            });

            DarkSkyForecast weatherOutput = await HttpRequestHelper.GetWeatherForecast(
                                                                    addressCoordinates.geometry.location.lat,
                                                                    addressCoordinates.geometry.location.lng,
                                                                    darkSkyApiKey,
                                                                    clientFactory);

            WeatherForecast response = new WeatherForecast(weatherOutput);

            this.weatherCache.Add(this.locationCache.Get(address).ToString(), response);

            return response;
        }
    }
}
