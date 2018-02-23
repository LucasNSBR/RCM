using RCM.Domain.Models;
using RCM.Domain.Validations.DuplicataCommandValidations;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class AddDuplicataCommand : DuplicataCommand
    {
        public AddDuplicataCommand(Duplicata duplicata) : base(duplicata)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
