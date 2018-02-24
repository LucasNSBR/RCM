using FluentValidation;
using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public abstract class BancoCommandValidator<T> : AbstractValidator<T> where T : BancoCommand
    {
        public BancoCommandValidator()
        {
        }

        public void ValidateName()
        {
            RuleFor(b => b.Banco.Nome)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(50)
                .WithMessage("O nome do banco deve ter entre 4 e 50 caracteres e não pode estar vazio.");
        }
    }
}
