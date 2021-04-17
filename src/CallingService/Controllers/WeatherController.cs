using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CallingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(IHttpClientFactory factory, ILogger<WeatherController> logger)
        {
            _client = factory.CreateClient("weather-service");
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastResponse>> Get()
        {
            var request = await _client.GetStringAsync("/weatherforecast");
            var items = JsonSerializer.Deserialize<IEnumerable<WeatherForecastResponse>>(request);

            return items;
        }
    }
}