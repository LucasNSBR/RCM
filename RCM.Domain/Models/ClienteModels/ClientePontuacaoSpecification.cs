using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClientePontuacaoSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly string _pontuacao;

        public ClientePontuacaoSpecification(string pontuacao)
        {
            _pontuacao = pontuacao;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_pontuacao != null)
                return f => _pontuacao == f.Pontuacao.ToString();

            return f => true;
        }
    }
}
