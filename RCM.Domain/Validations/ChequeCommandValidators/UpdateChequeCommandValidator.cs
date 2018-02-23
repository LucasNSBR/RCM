using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validations.ChequeCommandValidators
{
    public class UpdateChequeCommandValidator : ChequeCommandValidator<UpdateChequeCommand>
    {
        public UpdateChequeCommandValidator()
        {
            RuleFor(c => c.Cheque.Id)
                .NotEmpty()
                .WithMessage("O Id do cheque não deve estar em branco.");
        }
    }
}
