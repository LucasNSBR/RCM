using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class RepassarChequeCommandValidator : ChequeCommandValidator<RepassarChequeCommand>
    {
        void ValidateRepasseClienteId()
        {
            RuleFor(ch => ch.ClienteId)
                .NotEmpty()
                .WithMessage("O cheque deve estar relacionado a um cliente.");
        }

        public RepassarChequeCommandValidator()
        {
            ValidateId();
            ValidateDataRepasse();
        }
    }
}
