using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClientePontuacaoSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly int? _pontuacao;

        public ClientePontuacaoSpecification(int? pontuacao)
        {
            _pontuacao = pontuacao;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_pontuacao != null)
                return f => _pontuacao == (int)f.Pontuacao;

            return f => true;
        }
    }
}
