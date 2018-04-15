using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class DevolverChequeCommand : ChequeCommand
    {
        public DevolverChequeCommand(Guid id, DateTime dataEvento, string motivo)
        {
            Id = id;
            Motivo = motivo;
            DataEvento = dataEvento;
        }

        public override bool IsValid()
        {
            ValidationResult = new DevolverChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
