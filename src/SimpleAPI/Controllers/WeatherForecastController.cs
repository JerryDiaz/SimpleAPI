using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimpleAPI.Controllers
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

        public WeatherForecastController()
        {
        }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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

        [HttpGet("{name}")]
        public ActionResult<WeatherForecast> GetWeather(string name)
        {
            var rng = new Random();

            if(!string.IsNullOrEmpty(Array.Find(Summaries, x=> x.Equals(name))))
            {
                return new WeatherForecast {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = name
               }; 
            }else{
                return new WeatherForecast();
            }
        }   
        
        /* [HttpGet("{value}")]
        public ActionResult<bool> ExistWeather(string value){
            string weather = Array.Find(Summaries, x=> x.StartsWith(value,StringComparison.Ordinal));
            return string.IsNullOrEmpty(weather) ? false : true;
        } */
    }
}
