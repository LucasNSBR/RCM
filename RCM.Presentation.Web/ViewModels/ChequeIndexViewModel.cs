using RCM.Application.ViewModels;
using RCM.Application.ViewModels.ChequeViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class ChequeIndexViewModel
    {
        public PagedList<ChequeViewModel> Cheques { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }

        public Guid? ClienteId { get; set; }
        public string MinValor { get; set; }
        public string MaxValor { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string NumeroCheque { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
        public string Situacao { get; set; }

        public int TotalResultados { get; set; }
        public decimal ValorTotalResultados { get; set; }
        public decimal ValorTotalVencidos { get; set; }
    }
}
