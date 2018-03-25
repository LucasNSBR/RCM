using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Validators.DuplicataCommandValidations;

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
