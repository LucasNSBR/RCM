using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AttachFornecedorCommandValidator : ProdutoCommandValidator<AttachFornecedorCommand>
    {
        private void ValidateFornecedorId()
        {
            RuleFor(p => p.FornecedorId)
                .NotEmpty()
                .WithMessage("O Id da aplicação não pode estar vazio.");
        }

        private void ValidateDisponibilidade()
        {
            RuleFor(p => p.Disponibilidade)
                .NotEmpty()
                .WithMessage("Os dados da disponibilidade não podem estar vazios.");
        }

        private void ValidatePrecoCusto()
        {
            RuleFor(p => p.PrecoCusto)
                .NotEmpty()
                .WithMessage("O valor do preço de custo deve estar em um formato válido.");
        }

        public AttachFornecedorCommandValidator()
        {
            ValidateId();
            ValidateFornecedorId();
            ValidateDisponibilidade();
            ValidatePrecoCusto();
        }
    }
}
