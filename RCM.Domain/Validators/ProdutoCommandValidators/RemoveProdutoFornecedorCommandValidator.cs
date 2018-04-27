using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class RemoveProdutoFornecedorCommandValidator : ProdutoCommandValidator<RemoveProdutoFornecedorCommand>
    {
        private void ValidateFornecedorId()
        {
            RuleFor(ap => ap.FornecedorId)
                .NotEmpty()
                .WithMessage("O Id do fornecedor não pode estar vazio.");
        }

        public RemoveProdutoFornecedorCommandValidator()
        {
            ValidateId();
            ValidateFornecedorId();
        }
    }
}
