using RCM.Domain.Models.VendaModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.VendaViewModels
{
    public class CondicaoPagamentoViewModel
    {
        [Display(Name = "Id da Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid VendaId { get; set; }

        [Display(Name = "Venda")]
        public VendaViewModel Venda { get; set; }

        [Display(Name = "Tipo de Venda")]
        public TipoVenda TipoVenda { get; set; }

        [Display(Name = "Quantidade de Parcelas")]
        public int QuantidadeParcelas { get; set; }

        [Display(Name = "Intervalo de Vencimento")]
        public int IntervaloVencimento { get; set; }

        [Display(Name = "Valor de Entrada")]
        public decimal ValorEntrada { get; set; }
        
        [Display(Name = "Valor Pago")]
        public decimal ValorPago { get; set; }

        [Display(Name = "Valor Restante")]
        public decimal ValorRestante { get; set; }

        [Display(Name = "Parcelas")]
        public List<ParcelaViewModel> Parcelas { get; set; }
    }
}
