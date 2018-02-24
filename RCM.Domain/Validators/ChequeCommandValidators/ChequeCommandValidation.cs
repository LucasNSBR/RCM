using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;
using System;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public abstract class ChequeCommandValidator<T> : AbstractValidator<T> where T : ChequeCommand
    {
        public ChequeCommandValidator()
        {
            RuleFor(ch => ch.Cheque.NumeroCheque)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(8)
                .WithMessage("O número do cheque deve ter entre 6 e 8 caracteres e não pode estar em branco.");

            RuleFor(ch => ch.Cheque.BancoId)
                .NotEmpty()
                .WithMessage("O cheque deve estar relacionado a um banco.");

            RuleFor(ch => ch.Cheque.Agencia)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(5)
                .WithMessage("A agência deve ter entre 4 e 5 caracteres e não deve estar em branco.");

            RuleFor(ch => ch.Cheque.ClienteId)
                .NotEmpty()
                .WithMessage("O cheque deve estar relacionado a um cliente.");

            RuleFor(ch => ch.Cheque.Conta)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(12)
                .WithMessage("A conta deve ter entre 6 e 10 caracteres e não deve estar em branco.");

            RuleFor(ch => ch.Cheque.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de emissão deve estar em um formato válido.");

            RuleFor(ch => ch.Cheque.DataVencimento)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de vencimento deve estar em um formato válido.");

            RuleFor(ch => ch.Cheque.Valor)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor do cheque deve ser maior que 0.");
        }
    }
}
