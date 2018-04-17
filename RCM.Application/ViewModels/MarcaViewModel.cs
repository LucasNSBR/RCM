using System.Collections.Generic;

namespace RCM.Application.ViewModels
{
    public class MarcaViewModel
    {
        public string Nome { get; set; }
        public string Observacao { get; set; }

        private List<ProdutoViewModel> Produtos { get; set; }
    }
}
