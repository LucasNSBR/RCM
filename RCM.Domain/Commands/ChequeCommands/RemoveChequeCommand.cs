using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class RemoveChequeCommand : ChequeCommand
    {
        public RemoveChequeCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
