using FluentValidation;
using RCM.Domain.Commands.VendaCommands;
using System;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class VendaCommandValidator<T> : AbstractValidator<T> where T : VendaCommand
    {
        protected void ValidateId()
        {
            RuleFor(d => d.VendaId)
                .NotEmpty()
                .WithMessage("O Id da venda não deve estar vazio.");
        }

        public void ValidateDataVenda()
        {
            RuleFor(d => d.DataVenda)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-7))
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data da venda deve estar em um formato válido.");
        }

        public void ValidateClienteId()
        {
            RuleFor(d => d.ClienteId)
                .NotEmpty()
                .WithMessage("A venda deve estar relacionada a um cliente.");
        }
        
        public void ValidateDetalhes()
        {
            RuleFor(d => d.Detalhes)
                .MaximumLength(1000)
                .WithMessage("Os detalhes da venda devem ter até 1000 caracteres.");
        }
    }
}
