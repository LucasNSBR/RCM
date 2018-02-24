using FluentValidation;
using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public class UpdateBancoCommandValidator : BancoCommandValidator<UpdateBancoCommand>
    {
        public UpdateBancoCommandValidator()
        {
            RuleFor(b => b.Banco.Id)
               .NotEmpty()
               .WithMessage("O Id do banco não pode estar vazio.");
        }
    }
}
