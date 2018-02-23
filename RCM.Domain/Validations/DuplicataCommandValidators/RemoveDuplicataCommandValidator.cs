using FluentValidation;
using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validations.DuplicataCommandValidations
{
    public class RemoveDuplicataCommandValidator : DuplicataCommandValidator<RemoveDuplicataCommand>
    {
        public RemoveDuplicataCommandValidator() 
        {
            RuleFor(c => c.Duplicata.Id)
                .NotEmpty()
                .WithMessage("O Id da duplicata não deve estar em branco.");
        }
    }
}
