using FluentValidation;
using RCM.Domain.Commands.NotaFiscalCommands;
using System;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public abstract class NotaFiscalCommandValidator<T> : AbstractValidator<T> where T : NotaFiscalCommand
    {
        public NotaFiscalCommandValidator()
        {
        }

        protected void ValidateId()
        {
            RuleFor(n => n.NotaFiscal.Id)
                .NotEmpty()
                .WithMessage("O Id da nota fiscal não pode estar em branco.");
        }

        protected void ValidateNumeroDocumento()
        {
            RuleFor(n => n.NotaFiscal.NumeroDocumento)
                .NotEmpty()
                .Length(6)
                .WithMessage("O número da nota fiscal deve ter 6 caracteres e não deve estar em branco.");
        }

        protected void ValidateDataEmissao()
        {
            RuleFor(n => n.NotaFiscal.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(n => n.NotaFiscal.DataEmissao)
                .WithMessage("A data de emissão deve estar em um formato válido.");
        }

        protected void ValidateDataChegada()
        {
            RuleFor(n => n.NotaFiscal.DataChegada)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de chegada deve estar em um formato válido.");
        }

        protected void ValidateValor()
        {
            RuleFor(n => n.NotaFiscal.Valor)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O valor da nota fiscal deve ser maior que 0.");
        }
    }
}
