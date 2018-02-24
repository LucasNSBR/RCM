using FluentValidation;
using RCM.Domain.Commands.FornecedorCommands;

namespace RCM.Domain.Validators.FornecedorCommandValidators
{
    public class RemoveFornecedorCommandValidator : FornecedorCommandValidator<RemoveFornecedorCommand>
    {
        public RemoveFornecedorCommandValidator()
        {
            RuleFor(f => f.Fornecedor.Id)
                .NotEmpty()
                .WithMessage("O Id do fornecedor não deve estar em branco.");
        }
    }
}
