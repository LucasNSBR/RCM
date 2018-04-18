using System;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacao
    {
        public Guid ProdutoId { get; private set; }
        public virtual Produto Produto { get; private set; }
        public Guid AplicacaoId { get; private set; }
        public virtual Aplicacao Aplicacao { get; private set; }
    }
}
