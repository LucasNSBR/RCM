using FluentValidation;
using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public abstract class BancoCommandValidator<T> : AbstractValidator<T> where T : BancoCommand
    {
        protected void ValidateId()
        {
            RuleFor(b => b.Banco.Id)
                .NotEmpty()
                .WithMessage("O Id do banco não pode estar vazio.");
        }

        protected void ValidateCodigoCompensacao()
        {
            RuleFor(b => b.Banco.CodigoCompensacao)
                .NotEmpty()
                .InclusiveBetween(0, 9999)
                .WithMessage("O código de compensação do banco deve ter até 4 caracteres e não pode estar vazio.");
        }

        protected void ValidateName()
        {
            RuleFor(b => b.Banco.Nome)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(50)
                .WithMessage("O nome do banco deve ter entre 4 e 50 caracteres e não pode estar vazio.");
        }
    }
}
