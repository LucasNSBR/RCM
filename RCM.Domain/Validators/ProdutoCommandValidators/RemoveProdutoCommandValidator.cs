using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class RemoveProdutoCommandValidator : ProdutoCommandValidator<RemoveProdutoCommand>
    {
        public RemoveProdutoCommandValidator()
        {
            ValidateId();
        }
    }
}
