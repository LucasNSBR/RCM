using System;
using RCM.Domain.Validators.DuplicataCommandValidators;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class PagarDuplicataCommand : DuplicataCommand
    {
        public DateTime DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
        
        public PagarDuplicataCommand(Guid id, DateTime dataPagamento, decimal valorPago)
        {
            Id = id;
            DataPagamento = dataPagamento;
            ValorPago = valorPago;
        }

        public override bool IsValid()
        {
            ValidationResult = new PagarDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
