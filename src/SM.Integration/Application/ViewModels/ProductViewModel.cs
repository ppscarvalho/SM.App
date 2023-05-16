﻿using System.ComponentModel.DataAnnotations;

namespace SM.Integration.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Fornecedor do Produto obrigatório.")]
        public Guid SupplierId { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria do Produto obrigatório.")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do Produto obrigatória.")]
        public string? Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição do Produto obrigatória.")]
        public string? Description { get; set; }

        [Display(Name = "Preço de Compra")]
        [Required(ErrorMessage = "Preço de Compra do Produto obrigatório.")]
        public decimal PurchaseValue { get; set; }

        [Display(Name = "Preço de Venda")]
        [Required(ErrorMessage = "Preço de Venda do Produto obrigatório.")]
        public decimal SaleValue { get; set; }

        [Display(Name = "Margem de Lucro")]
        [Required(ErrorMessage = "Margem de Lucro do Produto obrigatório.")]
        public decimal ProfitMargin { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "Estoque do Produto obrigatório.")]
        public int Stock { get; set; }
    }
}
