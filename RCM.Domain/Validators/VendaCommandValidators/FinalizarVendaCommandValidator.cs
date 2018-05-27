using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class FinalizarVendaCommandValidator : VendaCommandValidator<FinalizarVendaCommand>
    {
        public FinalizarVendaCommandValidator()
        {
            ValidateVendaId();
            ValidateIntervaloVencimento();
            ValidateQuantidadeParcelas();
            ValidateValorEntrada();
        }

        private void ValidateTipoVenda()
        {
            RuleFor(v => v.TipoVenda)
                .IsInEnum();
        }

        private void ValidateIntervaloVencimento()
        {
            RuleFor(v => v.IntervaloVencimento)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(30);
        }

        private void ValidateQuantidadeParcelas()
        {
            RuleFor(v => v.QuantidadeParcelas)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(6);
        }

        private void ValidateValorEntrada()
        {
            RuleFor(v => v.ValorEntrada)
                .GreaterThanOrEqualTo(0);
        }
    }
}
