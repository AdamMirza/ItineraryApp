using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Util
{
    public class ItineraryConstants
    {
        public class AzureConstants
        {
            public const string DarkSkyKeyVault = "dark-sky-key";
            public const string GoogleMapsKeyVault = "google-maps-geocoding-key";
        }

        public class ApiUrlConstants
        {
            public const string GoogleMaps_Geocode = "https://maps.googleapis.com/maps/api/geocode/json";
            public const string DarkSky_Forecast = "https://api.darksky.net/forecast";
        }
    }
}
