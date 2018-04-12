using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class CompensarChequeCommand : ChequeCommand
    {
        public CompensarChequeCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CompensarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
