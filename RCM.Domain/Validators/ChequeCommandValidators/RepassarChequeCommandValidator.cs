using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class RepassarChequeCommandValidator : ChequeCommandValidator<RepassarChequeCommand>
    {
        public RepassarChequeCommandValidator()
        {
            ValidateId();
            ValidateDataRepasse();
        }

        private void ValidateRepasseClienteId()
        {
            RuleFor(ch => ch.ClienteId)
                .NotEmpty();
        }

        private void ValidateDataRepasse()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao);
        }
    }
}
