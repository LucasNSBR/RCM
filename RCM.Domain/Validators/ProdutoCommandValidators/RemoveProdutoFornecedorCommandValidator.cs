using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class RemoveProdutoFornecedorCommandValidator : ProdutoCommandValidator<RemoveProdutoFornecedorCommand>
    {
        public RemoveProdutoFornecedorCommandValidator()
        {
            ValidateId();
            ValidateFornecedorId();
        }

        private void ValidateFornecedorId()
        {
            RuleFor(ap => ap.FornecedorId)
                .NotEmpty();
        }
    }
}
