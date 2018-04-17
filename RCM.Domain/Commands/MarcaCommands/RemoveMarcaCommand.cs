using RCM.Domain.Validators.MarcaCommandValidators;
using System;

namespace RCM.Domain.Commands.MarcaCommands
{
    public class RemoveMarcaCommand : MarcaCommand
    {
        public RemoveMarcaCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveMarcaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
