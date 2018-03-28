using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.OrdemServicoModels
{
    public class OrdemServico
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
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

        private OrdemServico() { }

        public OrdemServico(Cliente cliente, List<Produto> produtos)
        {
            Cliente = cliente;
            _produtos = produtos;
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }
        
        public decimal CalcularTotal()
        {
            return Produtos.Sum(p => p.PrecoVenda);
        }
    }
}
