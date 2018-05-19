using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class CidadeIndexViewModel
    {
        public PagedList<CidadeViewModel> Cidades { get; set; }

        public string Nome { get; set; }
    }
}
