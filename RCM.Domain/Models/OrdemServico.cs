using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Produto> Produtos { get; }
        public decimal Total { get; }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }
        
        public decimal CalcularTotal()
        {
            return Produtos.Sum(p => p.PrecoVenda);
        }
    }
}
