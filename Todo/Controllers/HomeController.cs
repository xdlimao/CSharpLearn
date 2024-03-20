using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("oi")]
    public class HomeController : ControllerBase
    {
        private DataContext __dataContext;
        public HomeController(DataContext dataContext)
        {
            __dataContext = dataContext;
        }
        [HttpGet("peralta")]
        public IActionResult xd() => StatusCode(418, "burro");
        [HttpGet("a")]
        public IActionResult Get(/*[FromServices] DataContext dataContext*/)
            => Ok(__dataContext.Todos.ToList());
        [HttpGet("a/{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var entity = __dataContext.Todos.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }
        [HttpPost("a")]
        public IActionResult Post([FromBody] TodoModel model)
        {
            __dataContext.Todos.Add(model);
            __dataContext.SaveChanges();
            return Created($"{model.Title} adicionado com sucesso! (Isso aqui está no header)", model);
        }
        [HttpDelete("a")]
        public IActionResult Delete([FromHeader] int id = 0)
        {
            var entity = __dataContext.Todos.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return NotFound();
            __dataContext.Remove(entity);
            __dataContext.SaveChanges();
            return Ok("Deletado com sucesso o ID: " + id);
        }
        [HttpPut("a/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel model)
        {
            var entity = __dataContext.Todos.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                return NotFound();
            entity.Title = model.Title;
            entity.Done = model.Done;
            __dataContext.Update(entity);
            __dataContext.SaveChanges();
            return Ok(__dataContext.Todos.FirstOrDefault(x => x.Id == id));
        }
    }
}
