using FluentValidation;
using RCM.Domain.Commands.NotaFiscalCommands;
using System;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public abstract class NotaFiscalCommandValidator<T> : AbstractValidator<T> where T : NotaFiscalCommand
    {
        public NotaFiscalCommandValidator()
        {
            RuleFor(n => n.NotaFiscal.NumeroDocumento)
                .NotEmpty()
                .Length(6)
                .WithMessage("O número da nota fiscal deve ter 6 caracteres.");

            RuleFor(n => n.NotaFiscal.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de chegada deve estar em um formato válido.");

            RuleFor(n => n.NotaFiscal.DataChegada)
                .NotEmpty()
                .LessThanOrEqualTo(n => n.NotaFiscal.DataEmissao)
                .WithMessage("A data de emissão deve estar em um formato válido.");

            RuleFor(n => n.NotaFiscal.Valor)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O valor da nota fiscal deve ser maior que 0.");
        }
    }
}
