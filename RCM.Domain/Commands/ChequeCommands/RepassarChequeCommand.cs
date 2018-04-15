using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class RepassarChequeCommand : ChequeCommand
    {
        public Guid ClienteRepassadoId { get; set; }

        public RepassarChequeCommand(Guid id, DateTime dataEvento, Guid clienteRepassadoId)
        {
            Id = id;
            ClienteRepassadoId = clienteRepassadoId;
            DataEvento = dataEvento;
        }

        public override bool IsValid()
        {
            ValidationResult = new RepassarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
