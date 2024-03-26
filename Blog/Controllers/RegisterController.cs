using System.ComponentModel.DataAnnotations;
using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers;
[ApiController]
[Route("")]
public class RegisterController : ControllerBase
{
    private readonly BlogDataContext _dataContext;
    public RegisterController(BlogDataContext x)
    {
        _dataContext=x;
    }
    [HttpPost("register")]
    public async Task<IActionResult> register(
        [FromBody] RegisterViewModel model
    )
    {
        if (!ModelState.IsValid) //<- indica se o modelo é valido (faz jus ao nosso modelview que indicamos)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
        var user = new User //<- vamos inserir apenas as informações necessárias
        {
            Name=model.Name,
            Email=model.Email,
            Slug=model.Email.Replace("@","-").Replace(".","-")
        };
        var password = PasswordGenerator.Generate(25); //length: integer, includeSpecialChars: bool, upperCase: bool
        user.PasswordHash = PasswordHasher.Hash(password); //esse método converter aquela string para uma hash
        try
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new
            {
                user = user.Email, password = password //ou apenas password
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já está cadastrado"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno do servidor"));
        }
    }
}