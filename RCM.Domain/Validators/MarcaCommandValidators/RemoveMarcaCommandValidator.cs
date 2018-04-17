using RCM.Domain.Commands.MarcaCommands;

namespace RCM.Domain.Validators.MarcaCommandValidators
{
    public class RemoveMarcaCommandValidator : MarcaCommandValidator<RemoveMarcaCommand>
    {
        public RemoveMarcaCommandValidator()
        {
            ValidateId();
        }
    }
}
