using RCM.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.ProdutoModels
{
    public class Aplicacao : Entity<Aplicacao>
    {
        public virtual Carro Carro { get; set; }

        private List<ProdutoAplicacao> _produtos;
        public virtual IReadOnlyList<ProdutoAplicacao> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        protected Aplicacao() { }

        public Aplicacao(Guid id, Carro carro)
        {
            Id = id;
            Carro = carro;

            _produtos = new List<ProdutoAplicacao>();
        }

        public Aplicacao(Carro carro)
        {
            Carro = carro;

            _produtos = new List<ProdutoAplicacao>();
        }
    }
}
