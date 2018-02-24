using RCM.Domain.Models;
using RCM.Domain.Validators.DuplicataCommandValidations;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class UpdateDuplicataCommand : DuplicataCommand
    {
        public UpdateDuplicataCommand(Duplicata duplicata) : base(duplicata)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
