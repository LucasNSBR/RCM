using FluentValidation;
using RCM.Domain.Commands.CidadeCommands;

namespace RCM.Domain.Validators.CidadeCommandValidators
{
    public abstract class CidadeCommandValidator<T> : LocalizedAbstractValidator<T> where T : CidadeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty();
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .Length(3, 50);
        }

        protected void ValidateEstadoId()
        {
            RuleFor(c => c.EstadoId)
                .NotEmpty();
        }
    }
}
