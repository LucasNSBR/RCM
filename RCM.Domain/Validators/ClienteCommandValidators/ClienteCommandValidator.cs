using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public abstract class ClienteCommandValidator<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Cliente.Id)
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Cliente.Nome)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100)
                .WithMessage("O nome do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Cliente.Nome)
                .MaximumLength(100)
                .WithMessage("O nome do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }
    }
}
