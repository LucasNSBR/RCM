using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public class RemoveClienteCommandValidator : ClienteCommandValidator<RemoveClienteCommand>
    {
        public RemoveClienteCommandValidator()
        {
            ValidateId();
        }
    }
}
