using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validators.DuplicataCommandValidations
{
    public class RemoveDuplicataCommandValidator : DuplicataCommandValidator<RemoveDuplicataCommand>
    {
        public RemoveDuplicataCommandValidator() 
        {
            ValidateId();
        }
    }
}
