using RCM.Application.ViewModels;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class FornecedorIndexViewModel
    {
        public PagedList<FornecedorViewModel> Fornecedores { get; set; }
        
        public string Nome { get; set; }
    }
}
