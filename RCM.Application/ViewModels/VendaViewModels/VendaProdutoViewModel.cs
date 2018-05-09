using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class VendaProdutoViewModel
    {
        [Display(Name = "Id da Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Id da venda é requerido.")]
        public Guid VendaId { get; set; }

        [Display(Name = "Venda")]
        public VendaViewModel Venda { get; set; }

        [Display(Name = "Id do Produto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Id do produto é requerido.")]
        public Guid ProdutoId { get; set; }

        [Display(Name = "Produto")]
        public ProdutoViewModel Produto { get; set; }

        [Display(Name = "Preço de Venda")]
        public decimal PrecoVenda { get; set; }

        [Display(Name = "Desconto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O desconto do produto é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal Desconto { get; set; }

        [Display(Name = "Acréscimo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O acréscimo do produto é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal Acrescimo { get; set; }

        [Display(Name = "Preço Final")]
        public decimal PrecoFinal { get; set; }

        [Display(Name = "Quantidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A quantidade do produto é requerida.")]
        public int Quantidade { get; set; } = 1;

        public VendaProdutoViewModel()
        {
           
        }
    }
}
