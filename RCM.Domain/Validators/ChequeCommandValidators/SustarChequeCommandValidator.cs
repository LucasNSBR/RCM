using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class SustarChequeCommandValidator : ChequeCommandValidator<SustarChequeCommand>
    {
        public SustarChequeCommandValidator()
        {
            ValidateId();
        }
    }
}
