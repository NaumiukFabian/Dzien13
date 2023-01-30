using Microsoft.AspNetCore.Mvc;
using P05Sklep.Shared;

namespace P04Sklep.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("onlyTwo")]
        public IEnumerable<WeatherForecast> GetOnlyTwoWeatherForecast()
        {
            return new WeatherForecast[2]
            {
                new WeatherForecast()
                {
                    Summary="one"
                },
                new WeatherForecast()
                {
                    Summary="Two"
                }
            };
        }

        [HttpGet("search")]
        public IEnumerable<WeatherForecast> SearchTwoWeatherForecast([FromQuery] int number)
        {
            return Enumerable.Range(1, number).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("test/{myParam}")]
        public string GetValueFromPath([FromRoute] string myParam, [FromQuery] int number, [FromBody] Person person)
        {
            return $"this is result: myParam: {myParam}, number: {number}, Person: name:{person.Name}, age: {person.Age}";
        }

        [HttpGet("{email},{password}")]
        public IActionResult ManyArgumentsInPath(string email, string password)
        {
            return StatusCode(200, email + " - " + password);
        }

        [HttpPost("path1")]
        [HttpGet("path2")]
        [HttpGet("path3")]
        public IActionResult MultiplePathsOneMethod([FromBody] Person newPerson)
        {
            return Ok("Person added");
        }

        [HttpGet("[action]")]
        public IActionResult MyMethodName()
        {
            _logger.Log(LogLevel.Information, "method invokade");
            return Ok("method invoked");
        }
    }
}