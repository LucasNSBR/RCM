using RCM.Application.ViewModels;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class ChequesIndexViewModel
    {
        public IEnumerable<ChequeViewModel> Cheques { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
    }
}
