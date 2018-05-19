using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class BancoIndexViewModel
    {
        public PagedList<BancoViewModel> Bancos { get; set; }

        public string Nome { get; set; }
        public int? CodigoCompensacao { get; set; }
    }
}
