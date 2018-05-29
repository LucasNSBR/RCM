using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class PagarParcelaVendaCommand : VendaCommand
    {
        public int ParcelaId { get; set; }
        public DateTime DataPagamento { get; set; }

        public PagarParcelaVendaCommand(Guid vendaId, int parcelaId, DateTime dataPagamento)
        {
            VendaId = vendaId;
            ParcelaId = parcelaId;
            DataPagamento = dataPagamento;
        }

        public override bool IsValid()
        {
            ValidationResult = new PagarParcelaVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
