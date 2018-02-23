using RCM.Domain.Models;
using RCM.Domain.Validations.ClienteCommandValidators;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class AddClienteCommand : ClienteCommand
    {
        public AddClienteCommand(Cliente cliente) : base(cliente)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
