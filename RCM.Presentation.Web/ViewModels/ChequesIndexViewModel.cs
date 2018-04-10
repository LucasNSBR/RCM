using RCM.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class ChequesIndexViewModel
    {
        public PagedList<ChequeViewModel> Cheques { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }

        public decimal? MinValor { get; set; }
        public decimal? MaxValor { get; set; }
        public Guid? ClienteId { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string NumeroCheque { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
    }
}
