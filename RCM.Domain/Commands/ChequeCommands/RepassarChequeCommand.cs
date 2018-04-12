using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class RepassarChequeCommand : ChequeCommand
    {
        public RepassarChequeCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RepassarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
