using FluentValidation;
using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validations.DuplicataCommandValidations
{
    public class UpdateDuplicataCommandValidator : DuplicataCommandValidator<UpdateDuplicataCommand>
    {
        public UpdateDuplicataCommandValidator() 
        {
            RuleFor(c => c.Duplicata.Id)
                .NotEmpty()
                .WithMessage("O Id da duplicata não deve estar em branco.");
        }
    }
}
