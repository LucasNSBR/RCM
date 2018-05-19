using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ValueObjectViewModels
{
    public class PagamentoViewModel
    {
        [Display(Name = "Id da Duplicata")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid DuplicataId { get; set; }

        [Display(Name = "Data do Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Valor Pago")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public decimal ValorPago { get; set; }
    }
}
