using RCM.Domain.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacaoMotorSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _motor;

        public ProdutoAplicacaoMotorSpecification(string motor)
        {
            _motor = motor;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_motor != null)
                return p => p.Aplicacoes.Any(a => a.Aplicacao.Carro.Motor.Contains(_motor.ToLower()));

            return p => true;
        }
    }
}
