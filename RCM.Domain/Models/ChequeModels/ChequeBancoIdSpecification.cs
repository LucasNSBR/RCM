﻿using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeBancoIdSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly int? _bancoId;

        public ChequeBancoIdSpecification(int? bancoId)
        {
            _bancoId = bancoId; 
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_bancoId != null)
                return c => c.BancoId == _bancoId;

            return c => true;
        }
    }
}