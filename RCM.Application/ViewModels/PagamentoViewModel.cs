using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class PagamentoViewModel
    {
        [Display(Name = "Id da Duplicata")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A duplicata relacionada é requerida.")]
        public Guid DuplicataId { get; set; }

        [Display(Name = "Data do Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data do pagamento é requerido.")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Valor Pago")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor pago é requerido.")]
        public decimal ValorPago { get; set; }
    }
}
