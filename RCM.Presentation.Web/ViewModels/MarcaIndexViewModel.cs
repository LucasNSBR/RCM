using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class MarcaIndexViewModel
    {
        public PagedList<MarcaViewModel> Marcas { get; set; }

        public string Nome { get; set; }
    }
}
