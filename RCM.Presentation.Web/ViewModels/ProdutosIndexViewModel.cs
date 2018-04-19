using RCM.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class ProdutosIndexViewModel
    {
        public PagedList<ProdutoViewModel> Produtos { get; set; }
        public IEnumerable<MarcaViewModel> Marcas { get; set; }

        public string Nome { get; set; }
        public Guid? MarcaId { get; set; }
        public string MinValor { get; set; }
        public string MaxValor { get; set; }
        public int? MinQuantidade { get; set; }
        public int? MaxQuantidade { get; set; }
    }
}
