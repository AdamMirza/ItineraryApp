using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ItineraryBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ItineraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ILogger<TripController> _logger;

        public TripController(IConfiguration config, IHttpClientFactory httpClientFactory, ILogger<TripController> logger)
        {
            _logger = logger;
        }

        // GET: api/Trip
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Trip/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trip
        [HttpPost]
        public void Post([FromBody] Trip trip)
        {
        }

        // PUT: api/Trip/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip trip)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
