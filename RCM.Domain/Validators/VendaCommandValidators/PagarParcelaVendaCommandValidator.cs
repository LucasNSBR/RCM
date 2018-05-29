using FluentValidation;
using RCM.Domain.Commands.VendaCommands;
using System;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class PagarParcelaVendaCommandValidator : VendaCommandValidator<PagarParcelaVendaCommand>
    {
        public PagarParcelaVendaCommandValidator()
        {
            ValidateVendaId();
            ValidateDataPagamento();
        }

        public void ValidateParcelaId()
        {
            RuleFor(v => v.ParcelaId)
                .ExclusiveBetween(0, 7);
        }

        public void ValidateDataPagamento()
        {
            RuleFor(v => v.DataPagamento)
                .GreaterThan(DateTime.Now.AddDays(-7))
                .LessThan(DateTime.Now.AddDays(7))
                .WithMessage("A data desse pagamento deve ser maior que a data de abertura da venda");
        }
    }
}
