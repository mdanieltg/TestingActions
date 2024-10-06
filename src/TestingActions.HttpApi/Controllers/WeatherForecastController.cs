using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TestingActions.HttpApi.Models;

namespace TestingActions.HttpApi.Controllers;

[ApiController]
[Route("weatherforecast")]
[Produces(MediaTypeNames.Application.Json)]
public class WeatherForecastController : ControllerBase
{
    public static readonly string[] Summaries = new string[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public ActionResult<WeatherForecast[]> GetWeatherForecast()
    {
        WeatherForecast[] forecast = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToArray();

        return Ok(forecast);
    }
}
