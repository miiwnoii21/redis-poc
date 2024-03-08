using Microsoft.AspNetCore.Mvc;
using NRedisStack;

namespace Book.API.Controllers;

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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // [HttpPost(Name = "today")]
    // public bool SetTodayWeatherForecast(string weatherDesc)
    // {
    //     ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");
    //     var db = connection.GetDatabase();
    //     bool result = db.StringSet("weatherDesc", weatherDesc);
    //     Console.WriteLine(db.StringGet("weatherDesc"));
    //     return result;
    // }

    // [HttpGet(Name = "today")]
    // public string GetTodayWeatherForecast()
    // {
    //     ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");
    //     var db = connection.GetDatabase();
    //     var result = db.StringGet("weatherDesc");
    //     //db.StringIncrement()
    //     //result.
    // }
}
