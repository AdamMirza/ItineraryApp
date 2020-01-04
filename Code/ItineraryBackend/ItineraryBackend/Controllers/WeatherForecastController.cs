using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ItineraryBackend.Models;
using ItineraryBackend.Providers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ItineraryBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DarkSkyWeatherApi darkSkyWeatherApi;

        public WeatherForecastController(IConfiguration config, IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            darkSkyWeatherApi = new DarkSkyWeatherApi(config, httpClientFactory);
        }

        [HttpGet]
        public string Get()
        {
            return "Backend running";
        }

        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> Post(string address)
        {
            return await darkSkyWeatherApi.GetWeatherForecast(address);
        }
    }
}
