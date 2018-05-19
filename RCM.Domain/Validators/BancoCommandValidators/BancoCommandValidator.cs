using FluentValidation;
using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public abstract class BancoCommandValidator<T> : LocalizedAbstractValidator<T> where T : BancoCommand
    {
        protected void ValidateId()
        {
            RuleFor(b => b.Id)
                .NotEmpty();
        }

        protected void ValidateCodigoCompensacao()
        {
            RuleFor(b => b.CodigoCompensacao)
                .NotEmpty()
                .InclusiveBetween(0, 9999);
        }

        protected void ValidateName()
        {
            RuleFor(b => b.Nome)
                .NotEmpty()
                .Length(4, 50);
        }
    }
}
