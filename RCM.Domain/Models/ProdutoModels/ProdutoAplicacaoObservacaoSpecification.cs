using RCM.Domain.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacaoObservacaoSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _observacoes;

        public ProdutoAplicacaoObservacaoSpecification(string observacoes)
        {
            _observacoes = observacoes;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_observacoes != null)
                return p => p.Aplicacoes.Any(a => a.Aplicacao.Carro.Observacao.Contains(_observacoes.ToLower()));

            return p => true;
        }
    }
}
