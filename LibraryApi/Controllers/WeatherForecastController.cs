using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LibraryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : LibraryBaseController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IBookService _bookService;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        INotificator notificator,
        IBookService bookService
    ) : base(notificator)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        await _bookService.RegisterBook(new Book());

        if (IsValid()) return Ok("O Modelo está valido");
        return Ok(GetNotifications());

    }
}
