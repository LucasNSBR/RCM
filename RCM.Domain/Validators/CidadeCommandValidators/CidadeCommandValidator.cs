using FluentValidation;
using RCM.Domain.Commands.CidadeCommands;

namespace RCM.Domain.Validators.CidadeCommandValidators
{
    public abstract class CidadeCommandValidator<T> : AbstractValidator<T> where T : CidadeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O Id da cidade não pode estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("O nome da cidade deve ter entre 3 e 50 caracteres.");
        }

        protected void ValidateEstadoId()
        {
            RuleFor(c => c.EstadoId)
                .NotEmpty()
                .WithMessage("O Id do estado não pode estar vazio.");
        }
    }
}
