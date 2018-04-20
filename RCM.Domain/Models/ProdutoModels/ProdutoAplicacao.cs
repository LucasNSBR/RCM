using System;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacao : IEquatable<ProdutoAplicacao>
    {
        public Guid ProdutoId { get; private set; }
        public virtual Produto Produto { get; private set; }
        public Guid AplicacaoId { get; private set; }
        public virtual Aplicacao Aplicacao { get; private set; }

        protected ProdutoAplicacao() { }

        public ProdutoAplicacao(Produto produto, Aplicacao aplicacao)
        {
            Produto = produto;
            Aplicacao = aplicacao;
        }
        
        public bool Equals(ProdutoAplicacao other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;
            if (Produto.Id == other.Produto.Id && Aplicacao.Id == other.Aplicacao.Id)
                return true;

            return false; 
        }
    }
}
