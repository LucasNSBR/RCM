using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;
using System;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class BloquearChequeCommandValidator : ChequeCommandValidator<BloquearChequeCommand>
    {
        public BloquearChequeCommandValidator()
        {
            ValidateId();
            ValidateDataBloqueio();
        }

        private void ValidateDataBloqueio()
        {
            RuleFor(c => c.DataEvento)
                .NotEmpty()
                .ExclusiveBetween(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(7))
                .WithMessage("A data de bloqueio deve estar em um formato válido.");
        }
    }
}
