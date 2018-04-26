using RCM.Domain.Models.ProdutoModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ProdutoFornecedorViewModel
    {
        [Display(Name = "Preço de custo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo preço de custo é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal PrecoCusto { get; set; }

        [Display(Name = "Disponibilidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo disponibilidade é requerido.")]
        public ProdutoDisponibilidadeEnum Disponibilidade { get; set; }

        public Guid ProdutoId { get; set; }
        public Guid FornecedorId { get; set; }
    }
}
