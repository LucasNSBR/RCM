using RCM.Domain.Models;
using RCM.Domain.Validations.ClienteCommandValidators;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Cliente cliente) : base(cliente)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
