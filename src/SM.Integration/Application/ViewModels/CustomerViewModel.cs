using System.ComponentModel.DataAnnotations;

namespace SM.Integration.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string? FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Sobrenome fantasia é obritório.")]
        public string? LastName { get; set; }

        [Display(Name = "Celular")]
        public string? CellPhone { get; set; }

        [Display(Name = "E-mail")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Logradouro")]
        public string? PublicPlace { get; set; }

        [Display(Name = "Bairro")]
        public string? District { get; set; }

        [Display(Name = "Cidade")]
        public string? City { get; set; }

        [Display(Name = "CEP")]
        public string? ZipCode { get; set; }

        [Display(Name = "UF")]
        public string? State { get; set; }
        public IEnumerable<StateViewModel?>? States { get; set; }
    }
}
