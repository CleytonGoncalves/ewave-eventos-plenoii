using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Controllers.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class WeatherForecastController : ApiControllerBase
    {
        private static readonly string[] SUMMARIES = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(Status200OK)]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = SUMMARIES[rng.Next(SUMMARIES.Length)]
                })
                .ToArray();
        }
    }
}
