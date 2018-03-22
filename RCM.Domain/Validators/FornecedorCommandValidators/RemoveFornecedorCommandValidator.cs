using RCM.Domain.Commands.FornecedorCommands;

namespace RCM.Domain.Validators.FornecedorCommandValidators
{
    public class RemoveFornecedorCommandValidator : FornecedorCommandValidator<RemoveFornecedorCommand>
    {
        public RemoveFornecedorCommandValidator()
        {
            ValidateId();
        }
    }
}
