using RCM.Domain.Commands.CidadeCommands;

namespace RCM.Domain.Validators.CidadeCommandValidators
{
    public class RemoveCidadeCommandValidator : CidadeCommandValidator<RemoveCidadeCommand>
    {
        public RemoveCidadeCommandValidator()
        {
            ValidateId();
        }
    }
}
