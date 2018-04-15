using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class SustarChequeCommand : ChequeCommand
    {
        public SustarChequeCommand(Guid id, DateTime dataEvento, string motivo)
        {
            Id = id;
            Motivo = motivo;
            DataEvento = dataEvento;
        }

        public override bool IsValid()
        {
            ValidationResult = new SustarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
