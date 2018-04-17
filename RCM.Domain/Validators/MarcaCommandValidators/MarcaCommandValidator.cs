using FluentValidation;
using RCM.Domain.Commands.MarcaCommands;

namespace RCM.Domain.Validators.MarcaCommandValidators
{
    public abstract class MarcaCommandValidator<T> : AbstractValidator<T> where T : MarcaCommand
    {
        protected void ValidateId()
        {
            RuleFor(m => m.Id)
                .NotEmpty()
                .WithMessage("O Id da marca não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(m => m.Nome)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("O nome da marca deve ter até 100 caracteres e não deve estar em branco.");
        }
    }
}
