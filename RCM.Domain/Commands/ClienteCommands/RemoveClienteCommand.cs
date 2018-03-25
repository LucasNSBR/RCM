using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Validators.ClienteCommandValidators;

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
