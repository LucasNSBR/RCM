using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class BloquearChequeCommandValidator : ChequeCommandValidator<BloquearChequeCommand>
    {
        public BloquearChequeCommandValidator()
        {
            ValidateId();
        }
    }
}
