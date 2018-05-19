using FluentValidation;
using RCM.Domain.Commands.DuplicataCommands;
using System;

namespace RCM.Domain.Validators.DuplicataCommandValidators
{
    public class PagarDuplicataCommandValidator : DuplicataCommandValidator<PagarDuplicataCommand>
    {
        public PagarDuplicataCommandValidator()
        {
            ValidateId();
            ValidateValorPago();
            ValidateDataPagamento();
        }

        private void ValidateValorPago()
        {
            RuleFor(d => d.ValorPago)
                .NotEmpty();
        }

        private void ValidateDataPagamento()
        {
            RuleFor(d => d.DataPagamento)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}
