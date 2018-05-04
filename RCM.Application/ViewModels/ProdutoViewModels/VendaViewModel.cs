using RCM.Domain.Models.VendaModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Application.ViewModels
{
    public class VendaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public string Detalhes { get; set; }

        public List<ProdutoVendaViewModel> Produtos { get; set; }

        public int TotalProdutos
        {
            get
            {
                return Produtos.Count();
            }
        }

        public decimal TotalVenda
        {
            get
            {
                return Produtos.Sum(pv => pv.PrecoFinal);
            }
        }

        public VendaStatusEnum Status { get; set; }

        public VendaViewModel()
        {
            Produtos = Produtos ?? new List<ProdutoVendaViewModel>();
        }
    }
}
