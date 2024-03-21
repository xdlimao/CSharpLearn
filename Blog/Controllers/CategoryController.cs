using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("categories")]
        public async Task<IActionResult> GetsAsync(
            [FromServices] BlogDataContext dataContext
        )
        {
            try 
            {
                var categories = await dataContext.Categories.ToListAsync();
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<List<Category>>("Erro de Servidor"));
            }
        }
        [HttpGet("categories/{id:int}")]
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext dataContext,
            int id
        )
        {
            var category = await dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new ResultViewModel<Category>("Não encontrado valor"));
            return Ok(new ResultViewModel<Category>(category));
        }
        [HttpPost("categories")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext dataContext
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            try 
            {   
                var entity = new Category
                {
                    Name = model.Name,
                    Slug = model.Slug.ToLower(), //Esse campo é UNIQUE!!!
                    Posts = []
                };
                await dataContext.Categories.AddAsync(entity);
                await dataContext.SaveChangesAsync();
                return Created($"categories/{entity.Id}", new ResultViewModel<Category>(entity));   
            }
            catch (DbUpdateException e) {
                return BadRequest(new ResultViewModel<Category>("Não foi possível incluir a categoria"));
            }
            catch (Exception e) {return StatusCode(500, new ResultViewModel<Category>("Erro"));}      
        }
        [HttpPut("categories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext dataContext
        )
        {
            try 
            {
                var entity = await dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    return NotFound();
                entity.Name = model.Name;
                entity.Slug = model.Slug;
                dataContext.Categories.Update(entity);
                await dataContext.SaveChangesAsync();
                return Ok(new ResultViewModel<Category>(entity)); 
            }
            catch (DbUpdateException e)
            {
                return BadRequest(new ResultViewModel<Category>("Não vou possível alterar/atualizar o objeto"));
            }
            catch (Exception e) {return StatusCode(500, new ResultViewModel<Category>("Erro no servidor."));}
        }
        [HttpDelete("categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext dataContext
        )
        {
            try 
            {
                var entity = await dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    return NotFound();
                dataContext.Categories.Remove(entity);
                await dataContext.SaveChangesAsync();
                return Ok(new ResultViewModel<Category>($"Deleted {entity.Id}"));
            }
            catch (DbUpdateException e)
            {
                return BadRequest(new ResultViewModel<Category>("Não vou possível deletar o objeto"));
            }
            catch (Exception e) { return StatusCode(500, new ResultViewModel<Category>("Erro no servidor.")); }
        }
        [HttpDelete("categories/all")]
        public async Task<IActionResult> DeletaAllAsync([FromServices] BlogDataContext dataContext)
        {
            var allcategories = await dataContext.Categories.ToListAsync();
            dataContext.Categories.RemoveRange(allcategories);
            await dataContext.SaveChangesAsync();
            return Ok(new ResultViewModel<Category>("Deletado tudo"));
        }
    }
}