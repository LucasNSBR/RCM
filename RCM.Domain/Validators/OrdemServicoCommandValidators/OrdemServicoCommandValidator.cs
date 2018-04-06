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
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar vazio.");
        }

        protected void ValidateClienteId()
        {
            RuleFor(os => os.ClienteId)
                .NotEmpty()
                .WithMessage("A ordem de serviço deve estar relacionada a um cliente.");
        }

        protected void ValidateDataEntrada()
        {
            RuleFor(os => os.DataEntrada)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de entrada deve estar em um formato válido.");
        }
    }
}
