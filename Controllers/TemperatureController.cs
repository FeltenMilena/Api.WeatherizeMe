using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeatherizeMe.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var temperature = new Random().Next(10, 40);
            return Ok(new { Temperature = temperature, Date = DateTime.UtcNow });
        }
    }
}
