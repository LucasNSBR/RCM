using FluentValidation;
using RCM.Domain.Commands.FornecedorCommands;

namespace RCM.Domain.Validators.FornecedorCommandValidators
{
    public abstract class FornecedorCommandValidator<T> : AbstractValidator<T> where T: FornecedorCommand
    {
        public FornecedorCommandValidator()
        {
        }

        protected void ValidateId()
        {
            RuleFor(f => f.Fornecedor.Id)
                .NotEmpty()
                .WithMessage("O Id do fornecedor não deve estar em branco.");
        }

        protected void ValidateNome()
        {
            RuleFor(f => f.Fornecedor.Nome)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(100)
               .WithMessage("O nome do fornecedor deve ter entre 10 e 100 caracteres e não pode estar em branco.");
        }
    }
}
