using RCM.Domain.Validators.ClienteCommandValidators;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Guid id) 
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
