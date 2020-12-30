using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyApiWeb.Controllers
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

        [HttpGet("realweather/{pass}/{city}")]
        public IActionResult GetRealWeather(string pass = "myrealweather2020", string city = "Vila Nova de Famalicão")
        {
          string appId = "a9b1b6146e4cda8408cc2988bcdc95da";
          string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", city, appId);

          if (pass != "myrealweather2020")
          {
              return Unauthorized();
          }

          try
          {
            using (WebClient client = new WebClient())  
            {  
                string json = client.DownloadString(url);  
                var jsonstring = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented);
                return Ok(jsonstring);
            }
          }
          catch (Exception ex)
          {
            return Ok(ex.Message);
          }
        }
    }
}
