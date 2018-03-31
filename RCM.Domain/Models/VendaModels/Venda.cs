using RCM.Domain.Core.Models;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.VendaModels
{
    public class Venda : Entity<Venda>
    {
        public DateTime DataVenda { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        private List<Produto> _produtos;
        public virtual IReadOnlyList<Produto> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        public decimal Total { get; private set; }

        protected Venda() { }

        public Venda(Cliente cliente, DateTime dataVenda, List<Produto> produtos)
        {
            Cliente = cliente;
            DataVenda = dataVenda;
            _produtos = produtos;
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public decimal Finalizar()
        {
            return Produtos.Sum(p => p.PrecoVenda);
        }
    }
}
