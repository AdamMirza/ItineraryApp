using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ItineraryBackend.Models;
using ItineraryBackend.Providers;
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
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<DarkSkyForecast>> Post(string address)
        {
            return await darkSkyWeatherApi.GetWeatherForecast(address);
        }
    }
}
