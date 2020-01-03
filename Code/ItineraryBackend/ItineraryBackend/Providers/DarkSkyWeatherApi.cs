using ItineraryBackend.Models;
using ItineraryBackend.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<DarkSkyForecast> GetWeatherForecast(string address)
        {
            var darkSkyApiKey = config[ItineraryConstants.AzureConstants.DarkSkyKeyVault];
            var googleMapsApiKey = config[ItineraryConstants.AzureConstants.GoogleMapsKeyVault];

            AddressResult addressCoordinates = HttpRequestHelper.GetLatLong(address, googleMapsApiKey, clientFactory).Result.Results[0];
            DarkSkyForecast weatherOutput = await HttpRequestHelper.GetWeatherForecast(
                                                                    addressCoordinates.Geometry.Location.Lat,
                                                                    addressCoordinates.Geometry.Location.Long,
                                                                    darkSkyApiKey,
                                                                    clientFactory);

            return weatherOutput;
        }
    }
}
