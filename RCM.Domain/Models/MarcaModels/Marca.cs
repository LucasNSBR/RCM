using RCM.Domain.Core.Models;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.MarcaModels
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

        public Marca(Guid id, string nome, string observacao = null)
        {
            Id = id;
            Nome = nome;
            Observacao = observacao;

            _produtos = new List<Produto>();
        }

        public Marca(string nome, string observacao = null)
        {
            Nome = nome;
            Observacao = observacao;

            _produtos = new List<Produto>();
        }
    }
}
