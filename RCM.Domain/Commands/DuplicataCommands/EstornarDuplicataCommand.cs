using RCM.Domain.Validators.DuplicataCommandValidators;
using System;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class EstornarDuplicataCommand : DuplicataCommand
    {
        public EstornarDuplicataCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new EstornarDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
