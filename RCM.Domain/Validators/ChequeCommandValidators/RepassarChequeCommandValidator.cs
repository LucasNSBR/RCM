using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class RepassarChequeCommandValidator : ChequeCommandValidator<RepassarChequeCommand>
    {
        public RepassarChequeCommandValidator()
        {
            ValidateId();
        }
    }
}
