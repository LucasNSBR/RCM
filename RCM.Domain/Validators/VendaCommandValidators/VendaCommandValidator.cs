using FluentValidation;
using RCM.Domain.Commands.VendaCommands;
using System;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class VendaCommandValidator<T> : AbstractValidator<T> where T : VendaCommand
    {
        protected void ValidateVendaId()
        {
            RuleFor(d => d.VendaId)
                .NotEmpty();
        }

        protected void ValidateDataVenda()
        {
            RuleFor(d => d.DataVenda)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-7))
                .LessThanOrEqualTo(DateTime.Now);
        }

        protected void ValidateClienteId()
        {
            RuleFor(d => d.ClienteId)
                .NotEmpty();
        }

        protected void ValidateDetalhes()
        {
            RuleFor(d => d.Detalhes)
                .MaximumLength(1000);
        }
    }
}
