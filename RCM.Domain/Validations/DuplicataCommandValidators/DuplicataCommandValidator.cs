using FluentValidation;
using RCM.Domain.Commands.DuplicataCommands;
using System;

namespace RCM.Domain.Validations.DuplicataCommandValidations
{
    public abstract class DuplicataCommandValidator<T> : AbstractValidator<T> where T : DuplicataCommand
    {
        public DuplicataCommandValidator()
        {
            RuleFor(d => d.Duplicata.NumeroDocumento)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20)
                .WithMessage("O número do documento deve ter entre 5 e 20 caracteres e não pode estar vazio.");

            RuleFor(d => d.Duplicata.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de emissão deve estar em um formato válido.");

            RuleFor(d => d.Duplicata.DataVencimento)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de vencimento da duplicada deve estar em um formato válido.");

            RuleFor(d => d.Duplicata.Valor)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O valor da duplicata deve ser maior que 0 e não pode estar vazio");
        }
    }
}
