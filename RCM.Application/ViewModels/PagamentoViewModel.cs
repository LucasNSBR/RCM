using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class PagamentoViewModel
    {
        [Display(Name = "Data do Pagamento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data do pagamento é requerido.")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Valor Pago")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor pago é requerido.")]
        public decimal ValorPago { get; set; }

        public bool IsEmpty {
            get
            {
                return DataPagamento == DateTime.MinValue;   
            }
        }
    }
}
