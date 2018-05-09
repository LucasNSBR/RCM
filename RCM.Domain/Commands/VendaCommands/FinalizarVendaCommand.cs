using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class FinalizarVendaCommand : VendaCommand
    {
        public FinalizarVendaCommand(Guid vendaId)
        {
            VendaId = vendaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new FinalizarVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
