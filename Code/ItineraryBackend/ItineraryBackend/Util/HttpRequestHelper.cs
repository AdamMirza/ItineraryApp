using ItineraryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ItineraryBackend.Util
{
    public static class HttpRequestHelper
    {
        public static async Task<GoogleMapsAddress> GetLatLong(string address, string key, IHttpClientFactory clientFactory)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ItineraryConstants.ApiUrlConstants.GoogleMaps_Geocode + $"?address={address}&key={key}");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            GoogleMapsAddress output;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                output = await JsonSerializer.DeserializeAsync<GoogleMapsAddress>(responseStream);
            }
            else
            {
                throw new Exception("Get lat long failed");
            }

            return output;
        }

        public static async Task<DarkSkyForecast> GetWeatherForecast(float latitude, float longitude, string key, IHttpClientFactory clientFactory)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ItineraryConstants.ApiUrlConstants.GoogleMaps_Geocode + $"/{key}/{latitude},{longitude}?exclude=currently,minutely,hourly,alerts,flags&units=si");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            DarkSkyForecast output;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                output = await JsonSerializer.DeserializeAsync<DarkSkyForecast>(responseStream);
            }
            else
            {
                throw new Exception("Get weather failed");
            }

            return output;
        }
    }
}
