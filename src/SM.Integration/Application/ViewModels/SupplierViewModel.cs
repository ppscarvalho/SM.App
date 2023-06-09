﻿using System.ComponentModel.DataAnnotations;

namespace SM.Integration.Application.ViewModels
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Razão Social é obrigatória.")]
        public string? CorporateName { get; set; }

        [Display(Name = "Nome de Fantasia")]
        [Required(ErrorMessage = "Nome fantasia é obritório.")]
        public string? FantasyName { get; set; }

        [Display(Name = "CNPJ")]
        public string? NRLE { get; set; }

        [Display(Name = "Insc. Estadual")]
        public string? StateRegistration { get; set; }

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
