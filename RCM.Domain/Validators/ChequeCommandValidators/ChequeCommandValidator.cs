using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;
using System;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public abstract class ChequeCommandValidator<T> : LocalizedAbstractValidator<T> where T : ChequeCommand
    {
        protected void ValidateId()
        {
            RuleFor(ch => ch.Id)
                .NotEmpty();
        }

        protected void ValidateBancoId()
        {
            RuleFor(ch => ch.BancoId)
                .NotEmpty();
        }

        protected void ValidateAgencia()
        {
            RuleFor(ch => ch.Agencia)
                .NotEmpty()
                .Length(4, 5);
        }

        protected void ValidateConta()
        {
            RuleFor(ch => ch.Conta)
                .NotEmpty()
                .Length(4, 12);
        }

        protected void ValidateNumeroCheque()
        {
            RuleFor(ch => ch.NumeroCheque)
                .NotEmpty()
                .Length(6, 8);
        }

        protected void ValidateObservacao()
        {
            RuleFor(d => d.Observacao)
                .MaximumLength(1000);
        }

        protected void ValidateClienteId()
        {
            RuleFor(ch => ch.ClienteId)
                .NotEmpty();
        }

        protected void ValidateDataEmissao()
        {
            RuleFor(ch => ch.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }

        protected void ValidateDataVencimento()
        {
            RuleFor(ch => ch.DataVencimento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao);
        }

        protected void ValidateValor()
        {
            RuleFor(ch => ch.Valor)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
        }

        protected void ValidateMotivo()
        {
            RuleFor(ch => ch.Motivo)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
