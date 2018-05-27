using RCM.Domain.Models.VendaModels;
using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class FinalizarVendaCommand : VendaCommand
    {
        public TipoVenda TipoVenda { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int IntervaloVencimento { get; set; }
        public decimal ValorEntrada { get; set; }

        public FinalizarVendaCommand(Guid vendaId, TipoVenda tipoVenda, int quantidadeParcelas, int intervaloVencimento, decimal valorEntrada)
        {
            VendaId = vendaId;
            TipoVenda = tipoVenda;
            QuantidadeParcelas = quantidadeParcelas;
            IntervaloVencimento = intervaloVencimento;
            ValorEntrada = valorEntrada;
        }

        public override bool IsValid()
        {
            ValidationResult = new FinalizarVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
