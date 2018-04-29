using RCM.Domain.Validators.ClienteCommandValidators;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class RemoveClienteContatoCommand : ClienteCommand
    {
        public RemoveClienteContatoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteContatoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
