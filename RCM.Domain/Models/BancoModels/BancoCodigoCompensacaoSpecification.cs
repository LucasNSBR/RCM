using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.BancoModels
{
    public class BancoCodigoCompensacaoSpecification : BaseSpecification<Banco>, ISpecification<Banco>
    {
        private readonly int? _codigoCompensacao;

        public BancoCodigoCompensacaoSpecification(int? codigoCompensacao)
        {
            _codigoCompensacao = codigoCompensacao;
        }

        public override Expression<Func<Banco, bool>> ToExpression()
        {
            if (_codigoCompensacao != null)
                return b => b.CodigoCompensacao == _codigoCompensacao;

            return b => true;
        }
    }
}
