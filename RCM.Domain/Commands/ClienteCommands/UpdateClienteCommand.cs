using RCM.Domain.Models;
using RCM.Domain.Validations.ClienteCommandValidators;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Cliente cliente) : base(cliente)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
