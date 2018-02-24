using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class RemoveChequeCommandValidator : ChequeCommandValidator<RemoveChequeCommand>
    {
        public RemoveChequeCommandValidator()
        {
            RuleFor(c => c.Cheque.Id)
                .NotEmpty()
                .WithMessage("O Id do cheque não deve estar em branco.");
        }
    }
}
