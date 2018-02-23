using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validations.ClienteCommandValidators
{
    public class RemoveClienteCommandValidator : ClienteCommandValidator<RemoveClienteCommand>
    {
        public RemoveClienteCommandValidator()
        {
            RuleFor(c => c.Cliente.Id)
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar em branco.");
        }
    }
}
