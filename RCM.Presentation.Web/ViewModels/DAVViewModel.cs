using RCM.Application.ViewModels;
using RCM.Application.ViewModels.VendaViewModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class DAVViewModel
    {
        public VendaViewModel Venda { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
