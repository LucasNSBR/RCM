using FluentValidation;
using RCM.Domain.Commands.MarcaCommands;

namespace RCM.Domain.Validators.MarcaCommandValidators
{
    public abstract class MarcaCommandValidator<T> : AbstractValidator<T> where T : MarcaCommand
    {
        protected void ValidateId()
        {
            RuleFor(m => m.Id)
                .NotEmpty();
        }

        protected void ValidateNome()
        {
            RuleFor(m => m.Nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
