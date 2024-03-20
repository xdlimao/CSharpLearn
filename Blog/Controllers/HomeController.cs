using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("ye baby");
        }
    }
}