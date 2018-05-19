using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class CompensarChequeCommandValidator : ChequeCommandValidator<CompensarChequeCommand>
    {
        public CompensarChequeCommandValidator()
        {
            ValidateId();
            ValidateDataCompensacao();
        }

        private void ValidateDataCompensacao()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataVencimento);
        }
    }
}
