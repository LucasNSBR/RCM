using RCM.Domain.Models.ProdutoModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ProdutoViewModels
{
    public class ProdutoFornecedorViewModel
    {
        [Display(Name = "Id do Produto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid ProdutoId { get; set; }

        [Display(Name = "Produto")]
        public ProdutoViewModel Produto { get; set; }

        [Display(Name = "Id do Fornecedor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public FornecedorViewModel Fornecedor { get; set; }

        [Display(Name = "Referência do Fornecedor")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string ReferenciaFornecedor { get; set; }

        [Display(Name = "Preço de Custo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal PrecoCusto { get; set; }

        [Display(Name = "Disponibilidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        public ProdutoDisponibilidadeEnum Disponibilidade { get; set; }
    }
}
