using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class RemoveChequeCommandValidator : ChequeCommandValidator<RemoveChequeCommand>
    {
        public RemoveChequeCommandValidator()
        {
            ValidateId();
        }
    }
}
