using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace backend.Controllers;

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

    [HttpGet("/get")]
    public IActionResult Go()
    {
        Material text = new Material(1, 1, "Илья", "Илья", "", [1, 2, 3, 4, 5]);
        return Ok(text.TimeToLearn);
    }

    // [HttpPost("/api/login")]
    // public IActionResult Login([FromBody] IdentityUser user)
    // {
    //     IdentityUser u = new IdentityUser(user.Email);
    //     return Ok();
    // }
}
