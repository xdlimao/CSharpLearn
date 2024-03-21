using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "Ponha o nome burro")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Campo obrigátorioooo Slugger")]
        // [Range("0 to 10")]
        // [EmailAddress]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ponha o guls burro")]
        public string Slug { get; set; }
    }
}