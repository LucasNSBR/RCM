using RCM.Application.ViewModels;
using RCM.Application.ViewModels.ProdutoViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
{
    public class ProdutosIndexViewModel
    {
        public PagedList<ProdutoViewModel> Produtos { get; set; }
        public IEnumerable<MarcaViewModel> Marcas { get; set; }

        public string ProdutoId { get; set; }
        public string Nome { get; set; }
        public string AplicacaoMarca { get; set; }
        public string AplicacaoModelo { get; set; }
        public string AplicacaoMotor { get; set; }
        public int? AplicacaoAno { get; set; }
        public string AplicacaoObservacao { get; set; }
        public string ReferenciaFabricante { get; set; }
        public string ReferenciaOriginal { get; set; }
        public string ReferenciaAuxiliar { get; set; }
        public Guid? MarcaId { get; set; }
        public string MinValor { get; set; }
        public string MaxValor { get; set; }
        public int? MinEstoque { get; set; }
        public int? MaxEstoque { get; set; }
    }
}
