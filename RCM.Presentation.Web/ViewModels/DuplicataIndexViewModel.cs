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
        public decimal? MinValor { get; set; }
        public decimal? MaxValor { get; set; }
        public Guid? FornecedorId { get; set; }
        public string NumeroDocumento { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
    }
}
