using FluentValidation;
using RCM.Domain.Commands.NotaFiscalCommands;
using System;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public abstract class NotaFiscalCommandValidator<T> : AbstractValidator<T> where T : NotaFiscalCommand
    {
        protected void ValidateId()
        {
            RuleFor(n => n.Id)
                .NotEmpty();
        }

        protected void ValidateNumeroDocumento()
        {
            RuleFor(n => n.NumeroDocumento)
                .NotEmpty()
                .Length(6);
        }

        protected void ValidateDataEmissao()
        {
            RuleFor(n => n.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(n => n.DataEmissao);
        }

        protected void ValidateDataChegada()
        {
            RuleFor(n => n.DataChegada)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }

        protected void ValidateValor()
        {
            RuleFor(n => n.Valor)
                .NotEmpty()
                .InclusiveBetween(1, 99999);
        }
    }
}
