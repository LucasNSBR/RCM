using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class RepassarChequeCommand : ChequeCommand
    {
        public Guid FornecedorRepassadoId { get; set; }

        public RepassarChequeCommand(Guid id, DateTime dataEvento, Guid fornecedorRepassadoId)
        {
            Id = id;
            FornecedorRepassadoId = fornecedorRepassadoId;
            DataEvento = dataEvento;
        }

        public override bool IsValid()
        {
            ValidationResult = new RepassarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
