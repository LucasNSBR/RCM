using RCM.Application.ViewModels;
using RCM.Application.ViewModels.VendaViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class VendasIndexViewModel
    {
        public PagedList<VendaViewModel> Vendas { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }

        public Guid? ClienteId { get; set; }
        public string MinValor { get; set; }
        public string MaxValor { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string Status { get; set; }
    }
}
