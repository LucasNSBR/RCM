using RCM.Domain.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacaoMarcaSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _marca;

        public ProdutoAplicacaoMarcaSpecification(string marca)
        {
            _marca = marca;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_marca != null)
                return p => p.Aplicacoes.Any(a => a.Aplicacao.Carro.Marca.ToLower().Contains(_marca.ToLower()));

            return p => true;
        }
    }
}
