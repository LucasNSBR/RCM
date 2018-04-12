using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class CompensarChequeCommandValidator : ChequeCommandValidator<CompensarChequeCommand>
    {
        public CompensarChequeCommandValidator()
        {
            ValidateId();
        }
    }
}
