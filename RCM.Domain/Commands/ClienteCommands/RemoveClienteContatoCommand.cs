using RCM.Domain.Validators.ClienteCommandValidators;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class RemoveClienteContatoCommand : ClienteCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteContatoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
