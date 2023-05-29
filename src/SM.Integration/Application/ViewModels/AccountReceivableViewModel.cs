using System.ComponentModel.DataAnnotations;

namespace SM.Integration.Application.ViewModels
{
    public class AccountReceivableViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Cliente obrigatório.")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição da conta obrigatória.")]
        public string? Description { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Data de vencimento é obrigatória.")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Value { get; set; }

        public string? Status { get; set; }

        public ICollection<CustomerViewModel>? CustomerViewModels { get; set; }
        public CustomerViewModel? CustomerViewModel { get; set; }

        public string Situacao
        {
            get { return ObterSituacao(); }
        }
        public string ObterSituacao()
        {
            switch (Status)
            {
                case "PaidOut":
                    return "Pago";

                case "ToReceive":
                    return "A receber";

                case "Unpaid":
                    return "Não Pago";

                default:
                    return "Não Pago";
            }
        }
    }
}
