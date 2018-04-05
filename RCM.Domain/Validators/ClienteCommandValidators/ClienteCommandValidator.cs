using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public abstract class ClienteCommandValidator<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100)
                .WithMessage("O nome do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .MaximumLength(1000)
                .WithMessage("A descrição do cliente deve ter até 1000 caracteres.");
        }
    }
}
