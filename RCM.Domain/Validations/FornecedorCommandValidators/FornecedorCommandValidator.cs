using FluentValidation;
using RCM.Domain.Commands.FornecedorCommands;

namespace RCM.Domain.Validations.FornecedorCommandValidators
{
    public abstract class FornecedorCommandValidator<T> : AbstractValidator<T> where T: FornecedorCommand
    {
        public FornecedorCommandValidator()
        {
            RuleFor(f => f.Fornecedor.Nome)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100)
                .WithMessage("O nome do fornecedor deve ter entre 10 e 100 caracteres e não pode estar em branco.");
        }
    }
}
