using System.Collections.Generic;

namespace RCM.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<DuplicataViewModel> Duplicatas { get; set; }
        public ICollection<NotaFiscalViewModel> NotasFiscais { get; set; }
    }
}