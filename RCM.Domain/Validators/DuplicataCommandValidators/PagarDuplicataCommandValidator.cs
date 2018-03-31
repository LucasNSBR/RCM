using FluentValidation;
using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validators.DuplicataCommandValidators
{
    public class PagarDuplicataCommandValidator : DuplicataCommandValidator<PagarDuplicataCommand>
    {
        public PagarDuplicataCommandValidator()
        {
            ValidateId();
            ValidateValorPago();
            ValidateDataPagamento();
        }

        public void ValidateValorPago()
        {
            RuleFor(d => d.ValorPago)
                .NotEmpty()
                .WithMessage("O valor pago não deve estar vazia.");
        }

        public void ValidateDataPagamento()
        {
            RuleFor(d => d.DataPagamento)
                .NotEmpty()
                .WithMessage("A data de pagamento não deve estar vazia.");
        }
    }
}
