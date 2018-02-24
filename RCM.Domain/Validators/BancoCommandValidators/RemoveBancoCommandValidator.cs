using FluentValidation;
using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public class RemoveBancoCommandValidator : BancoCommandValidator<RemoveBancoCommand>
    {
        public RemoveBancoCommandValidator()
        {
            RuleFor(b => b.Banco.Id)
                .NotEmpty()
                .WithMessage("O Id do banco não pode estar vazio.");
        }
    }
}
