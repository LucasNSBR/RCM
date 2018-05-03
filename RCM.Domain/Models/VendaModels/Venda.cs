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

        private List<ProdutoVenda> _produtos;
        public virtual IReadOnlyList<ProdutoVenda> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        public decimal Total
        {
            get
            {
                return _produtos.Sum(p => p.Produto.PrecoVenda);
            }
        }
        
        public Venda(Cliente cliente, DateTime dataVenda)
        {
            Cliente = cliente;
            DataVenda = dataVenda;
            _produtos = new List<ProdutoVenda>();
        }

        public void AdicionarProduto(Produto produto)
        {
            ProdutoVenda produtoVenda = new ProdutoVenda(this, produto);

            if (!_produtos.Contains(produtoVenda))
                _produtos.Add(produtoVenda);
            else
                AddDomainError("O produto já foi adicionado à venda.");
        }

        public void RemoverProduto(Produto produto)
        {
            ProdutoVenda produtoVenda = new ProdutoVenda(this, produto);

            if (_produtos.Contains(produtoVenda))
                _produtos.Remove(produtoVenda);
            else
                AddDomainError("O produto ainda foi adicionado à venda.");
        }

        public decimal Finalizar()
        {
            return Produtos.Sum(p => p.Produto.PrecoVenda);
        }
    }
}
