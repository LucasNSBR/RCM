using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class CompensarChequeCommand : ChequeCommand
    {
        public CompensarChequeCommand(Guid id, DateTime dataEvento)
        {
            Id = id;
            DataEvento = dataEvento;
        }

        public override bool IsValid()
        {
            ValidationResult = new CompensarChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
