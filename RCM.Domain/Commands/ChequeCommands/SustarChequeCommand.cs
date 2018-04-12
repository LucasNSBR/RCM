using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class SustarChequeCommand : ChequeCommand
    {
        public SustarChequeCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new SustarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
