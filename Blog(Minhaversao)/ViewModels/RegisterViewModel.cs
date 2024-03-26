using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;
public class RegisterViewModel
{
    [Required(ErrorMessage = "O nome é obrigátorio")]
    public string Name { get; set; }
    [Required(ErrorMessage="O email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email é invalido")]
    public string Email { get; set; }
}