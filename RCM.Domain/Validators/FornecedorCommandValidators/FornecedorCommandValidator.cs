using FluentValidation;
using RCM.Domain.Commands.FornecedorCommands;

namespace RCM.Domain.Validators.FornecedorCommandValidators
{
    public abstract class FornecedorCommandValidator<T> : AbstractValidator<T> where T: FornecedorCommand
    {
        protected void ValidateId()
        {
            RuleFor(f => f.Id)
                .NotEmpty()
                .WithMessage("O Id do fornecedor não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(f => f.Nome)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(100)
               .WithMessage("O nome do fornecedor deve ter entre 10 e 100 caracteres e não pode estar vazio.");
        }

        protected void ValidateObservacao()
        {
            RuleFor(f => f.Observacao)
                .MaximumLength(1000)
                .WithMessage("O campo observação deve ter até 1000 caracteres.");
        }
    }
}
