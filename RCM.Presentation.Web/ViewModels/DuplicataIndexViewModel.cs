using RCM.Application.ViewModels;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class DuplicataIndexViewModel
    {
        public PagedList<DuplicataViewModel> Duplicatas { get; set; }
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}
