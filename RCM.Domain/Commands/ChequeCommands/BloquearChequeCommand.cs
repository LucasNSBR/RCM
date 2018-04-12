using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class BloquearChequeCommand : ChequeCommand
    {
        public BloquearChequeCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new BloquearChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
