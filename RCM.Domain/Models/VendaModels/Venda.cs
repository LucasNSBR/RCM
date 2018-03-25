using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.VendaModels
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Produto> Produtos { get; }
        public decimal Total { get; }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public decimal Finalizar()
        {
            return Produtos.Sum(p => p.PrecoVenda);
        }
    }
}
