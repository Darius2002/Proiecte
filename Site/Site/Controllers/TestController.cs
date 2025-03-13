using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello from ASP.NET!" });
        }
    }
}
