using Blog.Data;
using Blog.Extensions;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers;
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromServices] TokenService tokenService, [FromServices] BlogDataContext dataContext, [FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid) //<- verifica se o JSON que você enviou está de acordo com o LoginViewModel
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors())); 
        
        var user = await dataContext
            .Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == model.Email); //Chamamos um usuário com o Email que passamos lá no nosso ViewModel
        
        if (user == null) //Caso não exista ninguem com aquele email
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválido")); 
        
        if (!PasswordHasher.Verify(user.PasswordHash, model.Password)) //Caso não existe ninguem com a senha que você passou
            //Lembrando que o método Verify é o único jeito de verificar se o hash que você criou é igual com a senha sem o hash,
            //pois essa biblioteca sempre troca o hash e as senhas criptografadas nunca são do mesmo jeito.
            //Parametro: hashpassword (senha salva no banco com hash), password (senha que você passou na sua requisição)
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválido"));
        
        try
        {
            var token = tokenService.GenerateToken(user); //Cria o seu TokenJwt
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
        }
    }
    [Authorize(Roles="user")]
    [HttpGet("user")]
    public IActionResult GetUser() => Ok(User.Identity.Name);
    [Authorize(Roles="author")]
    [HttpGet("author")]
    public IActionResult GetAuthor() => Ok(User.Identity.Name);
    [Authorize(Roles="user")]
    [Authorize(Roles="author")]
    [Authorize(Roles="admin")]
    [HttpGet("admin")]
    public IActionResult GetAdmin() => Ok(User.Identity.Name);
    
}