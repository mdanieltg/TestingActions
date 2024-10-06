using Microsoft.AspNetCore.Mvc;
using TestingActions.HttpApi.Controllers;
using TestingActions.HttpApi.Models;

namespace TestingActions.UnitTests;

public class WeatherForecastTests
{
    [Test]
    public void WeatherForecastController_AlwaysReturnsForecasts()
    {
        // Prepare
        WeatherForecastController controller = new();

        // Act
        ActionResult<WeatherForecast[]> actionResult = controller.GetWeatherForecast();

        // Assert
        Assert.That(actionResult.Result, Is.Not.Null);
        Assert.That(actionResult.Result, Is.InstanceOf(typeof(OkObjectResult)));

        var okObjectResult = actionResult.Result as OkObjectResult;
        var weatherForecastArray = okObjectResult?.Value as WeatherForecast[];

        Assert.That(weatherForecastArray, Is.Not.Null);

        foreach (WeatherForecast weatherForecast in weatherForecastArray)
        {
            if (weatherForecast.Summary is not null)
                Assert.That(WeatherForecastController.Summaries.Any(s => weatherForecast.Summary == s), Is.True);
        }
    }
}
