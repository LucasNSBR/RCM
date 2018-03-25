using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.NotaFiscalModels
{
    public class NotaFiscalNumeroDocumentoSpecification : BaseSpecification<NotaFiscal>, ISpecification<NotaFiscal>
    {
        private readonly string _numeroDocumento;

        public NotaFiscalNumeroDocumentoSpecification(string numeroDocumento)
        {
            _numeroDocumento = numeroDocumento;
        }

        public override Expression<Func<NotaFiscal, bool>> ToExpression()
        {
            if (_numeroDocumento != null)
                return nf => nf.NumeroDocumento.ToLower().Contains(_numeroDocumento.ToLower());

            return nf => true;
        }
    }
}
