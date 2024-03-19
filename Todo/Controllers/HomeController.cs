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
        [HttpGet("a")]
        public List<TodoModel> Get(/*[FromServices] DataContext dataContext*/)
        {
            return __dataContext.Todos.ToList();
        }
        [HttpGet("a/{id:int}")]
        public TodoModel Get ([FromRoute]int id)
        {
            return __dataContext.Todos.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("a")]
        public string Post([FromBody] TodoModel model)
        {
            __dataContext.Todos.Add(model);
            __dataContext.SaveChanges();
            return $"{model.Title} adicionado com sucesso!";
        }
        [HttpDelete("a")]
        public string Delete([FromHeader] int id = 0)
        {
            if (id == 0)
                return "Especifique um valor valido";
            var entity = __dataContext.Todos.Where(x => x.Id == id).FirstOrDefault();
            __dataContext.Remove(entity);
            __dataContext.SaveChanges();
            return $"Deletado o ID {id} com sucesso!";
        }
        [HttpPut("a")]
        public TodoModel Put(TodoModel model)
        {
            __dataContext.Update(model);
            __dataContext.SaveChanges();
            return model;
        }
    }
}
