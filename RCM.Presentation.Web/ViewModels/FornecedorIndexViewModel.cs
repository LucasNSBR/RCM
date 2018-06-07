using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class FornecedorIndexViewModel
    {
        public PagedList<FornecedorViewModel> Fornecedores { get; set; }

        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string CadastroNacional { get; set; }
        public string CadastroEstadual { get; set; }
    }
}
