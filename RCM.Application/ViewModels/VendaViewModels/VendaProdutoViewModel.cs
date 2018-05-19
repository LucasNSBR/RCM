using RCM.Application.ViewModels.ProdutoViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.VendaViewModels
{
    public class VendaProdutoViewModel
    {
        [Display(Name = "Id da Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid VendaId { get; set; }

        [Display(Name = "Venda")]
        public VendaViewModel Venda { get; set; }

        [Display(Name = "Id do Produto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid ProdutoId { get; set; }

        [Display(Name = "Produto")]
        public ProdutoViewModel Produto { get; set; }

        [Display(Name = "Preço de Venda")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public decimal PrecoVenda { get; set; }

        [Display(Name = "Desconto")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public decimal Desconto { get; set; }

        [Display(Name = "Acréscimo")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} do produto é requerido.")]
        public decimal Acrescimo { get; set; }

        [Display(Name = "Preço Final")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} do é requerido.")]
        public decimal PrecoFinal { get; set; }

        [Display(Name = "Quantidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A quantidade do produto é requerida.")]
        public int Quantidade { get; set; } = 1;
    }
}
