using RCM.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class DuplicataIndexViewModel
    {
        public PagedList<DuplicataViewModel> Duplicatas { get; set; }
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }

        public bool? ApenasNaoPagas { get; set; }
        public bool? ApenasVencidas { get; set; }
        public Guid? FornecedorId { get; set; }
        public string NumeroDocumento { get; set; }
        public string MinValor { get; set; }
        public string MaxValor { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }

        public int TotalResultados { get; set; }
        public decimal ValorTotalResultados { get; set; }
        public decimal ValorTotalVencidas { get; set; }
    }
}
