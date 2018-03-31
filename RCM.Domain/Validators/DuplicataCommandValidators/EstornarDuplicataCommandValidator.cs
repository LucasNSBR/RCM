using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validators.DuplicataCommandValidators
{
    public class EstornarDuplicataCommandValidator : DuplicataCommandValidator<EstornarDuplicataCommand>
    {
        public EstornarDuplicataCommandValidator()
        {
            ValidateId();
        }
    }
}
