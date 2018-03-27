using System;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Validators.DuplicataCommandValidators;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class PagarDuplicataCommand : DuplicataCommand
    {
        public DateTime DataPagamento { get; private set; }
        public decimal ValorPago { get; private set; }
        
        public PagarDuplicataCommand(Duplicata duplicata, DateTime dataPagamento, decimal valorPago) : base(duplicata)
        {
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
