using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.MarcaModels
{
    public class MarcaNomeSpecification : BaseSpecification<Marca>, ISpecification<Marca>
    {
        private readonly string _nome;

        public MarcaNomeSpecification(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Marca, bool>> ToExpression()
        {
            if (_nome != null)
                return m => m.Nome.ToLower().Contains(_nome.ToLower());

            return m => true;
        }
    }
}
