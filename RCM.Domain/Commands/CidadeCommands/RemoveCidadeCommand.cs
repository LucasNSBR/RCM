using RCM.Domain.Validators.CidadeCommandValidators;
using System;

namespace RCM.Domain.Commands.CidadeCommands
{
    public class RemoveCidadeCommand : CidadeCommand
    {
        public RemoveCidadeCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCidadeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
