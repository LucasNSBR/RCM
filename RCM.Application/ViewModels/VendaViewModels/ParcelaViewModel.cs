using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.VendaViewModels
{
    public class ParcelaViewModel
    {
        [Display(Name = "Id da Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid VendaId { get; set; }

        [Display(Name = "Venda")]
        public VendaViewModel Venda { get; set; }

        [Display(Name = "Número da Parcela")]
        public int Numero { get; set; }

        [Display(Name = "Data de Vencimento da Parcela")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Valor da Parcela")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerido.")]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Pagamento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }

        #region View Helpers
        [Display(Name = "Parcela vencida")]
        public bool Vencida
        {
            get
            {
                return DateTime.Now > DataVencimento && DataPagamento == null;
            }
        }

        [Display(Name = "Parcela Paga")]
        public bool Paga { get; set; }
        #endregion
    }
}
