using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Validators.ClienteCommandValidators;

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
