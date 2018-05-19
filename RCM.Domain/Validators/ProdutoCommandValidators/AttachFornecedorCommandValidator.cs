using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AttachFornecedorCommandValidator : ProdutoCommandValidator<AttachFornecedorCommand>
    {
        public AttachFornecedorCommandValidator()
        {
            ValidateId();
            ValidateFornecedorId();
            ValidateDisponibilidade();
            ValidatePrecoCusto();
        }

        private void ValidateFornecedorId()
        {
            RuleFor(p => p.FornecedorId)
                .NotEmpty();
        }

        private void ValidateDisponibilidade()
        {
            RuleFor(p => p.Disponibilidade)
                .NotEmpty();
        }

        private void ValidatePrecoCusto()
        {
            RuleFor(p => p.PrecoCusto)
                .NotEmpty();
        }
    }
}
