using RCM.Domain.Core.Models;
using System.Collections.Generic;

namespace RCM.Domain.Models.ProdutoModels
{
    public class Marca : Entity<Marca>
    {
        public string Nome { get; private set; }
        public string Observacao { get; private set; }

        private List<Produto> _produtos;
        public virtual IReadOnlyList<Produto> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        protected Marca() { }

        public Marca(string nome, string observacao = null)
        {
            Nome = nome;
            Observacao = observacao;
        }
    }
}
