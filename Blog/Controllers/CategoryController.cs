using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> Get(
            [FromServices] BlogDataContext dataContext
        ) => Ok(await dataContext.Categories.ToListAsync());
    }
}