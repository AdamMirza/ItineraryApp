using ItineraryBackend.Models;
using ItineraryBackend.Util;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace ItineraryBackend.Providers
{
    public class DarkSkyWeatherApi
    {
        private readonly IConfiguration config;
        private readonly IHttpClientFactory clientFactory;

        public DarkSkyWeatherApi(IConfiguration config, IHttpClientFactory clientFactory)
        {
            this.config = config;
            this.clientFactory = clientFactory;
        }

        public async Task<WeatherForecast> GetWeatherForecast(string address)
        {
            var darkSkyApiKey = config[ItineraryConstants.AzureConstants.DarkSkyKeyVault];
            var googleMapsApiKey = config[ItineraryConstants.AzureConstants.GoogleMapsKeyVault];

            Result addressCoordinates = HttpRequestHelper.GetLatLong(address, googleMapsApiKey, clientFactory).Result.results[0];
            DarkSkyForecast weatherOutput = await HttpRequestHelper.GetWeatherForecast(
                                                                    addressCoordinates.geometry.location.lat,
                                                                    addressCoordinates.geometry.location.lng,
                                                                    darkSkyApiKey,
                                                                    clientFactory);

            return new WeatherForecast(weatherOutput);
        }
    }
}
