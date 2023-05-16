using System.ComponentModel.DataAnnotations;

namespace SM.Integration.Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Descrição da Categoria obrigatória.")]
        public string? Description { get; set; }
    }
}
