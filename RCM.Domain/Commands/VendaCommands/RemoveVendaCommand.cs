using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class RemoveVendaCommand : VendaCommand
    {
        public RemoveVendaCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
