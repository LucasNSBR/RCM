using RCM.Domain.Models;
using RCM.Domain.Validators.DuplicataCommandValidations;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class RemoveDuplicataCommand : DuplicataCommand
    {
        public RemoveDuplicataCommand(Duplicata duplicata) : base(duplicata)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
