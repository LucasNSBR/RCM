using FluentValidation;
using RCM.Domain.Commands.OrdemServicoCommands;
using System;

namespace RCM.Domain.Validators.OrdemServicoCommandValidators
{
    public abstract class OrdemServicoCommandValidator<T> : AbstractValidator<T> where T : OrdemServicoCommand
    {
        protected void ValidateId()
        {
            RuleFor(os => os.Id)
                .NotEmpty();
        }

        protected void ValidateClienteId()
        {
            RuleFor(os => os.ClienteId)
                .NotEmpty();
        }

        protected void ValidateDataEntrada()
        {
            RuleFor(os => os.DataEntrada)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}
