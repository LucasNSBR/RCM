using FluentValidation;
using RCM.Domain.Commands.DuplicataCommands;
using System;

namespace RCM.Domain.Validators.DuplicataCommandValidators
{
    public abstract class DuplicataCommandValidator<T> : LocalizedAbstractValidator<T> where T : DuplicataCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty(); 
        }

        protected void ValidateNumeroDocumento()
        {
            RuleFor(d => d.NumeroDocumento)
                .NotEmpty()
                .Length(5, 20); 
        }

        protected void ValidateObservacao()
        {
            RuleFor(d => d.Observacao)
                .MaximumLength(1000);
        }

        protected void ValidateDataEmissao()
        {
            RuleFor(d => d.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }

        protected void ValidateDataVencimento()
        {
            RuleFor(d => d.DataVencimento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao);
        }

        protected void ValidateFornecedorId()
        {
            RuleFor(d => d.FornecedorId)
                .NotEmpty();
        }

        protected void ValidateNotaFiscalId()
        {
            RuleFor(d => d.NotaFiscalId)
                .MaximumLength(6);
        }

        protected void ValidateValor()
        {
            RuleFor(d => d.Valor)
                .NotEmpty()
                .ExclusiveBetween(1, 99999);
        }
    }
}
