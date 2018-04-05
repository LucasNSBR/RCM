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
                .NotEmpty()
                .WithMessage("O Id da nota fiscal não pode estar vazio.");
        }

        protected void ValidateNumeroDocumento()
        {
            RuleFor(n => n.NumeroDocumento)
                .NotEmpty()
                .Length(6)
                .WithMessage("O número da nota fiscal deve ter 6 caracteres e não deve estar vazio.");
        }

        protected void ValidateDataEmissao()
        {
            RuleFor(n => n.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(n => n.DataEmissao)
                .WithMessage("A data de emissão deve estar em um formato válido.");
        }

        protected void ValidateDataChegada()
        {
            RuleFor(n => n.DataChegada)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de chegada deve estar em um formato válido.");
        }

        protected void ValidateValor()
        {
            RuleFor(n => n.Valor)
                .NotEmpty()
                .InclusiveBetween(1, 99999)
                .WithMessage("O valor da nota fiscal deve estar em um formato válido.");
        }
    }
}
