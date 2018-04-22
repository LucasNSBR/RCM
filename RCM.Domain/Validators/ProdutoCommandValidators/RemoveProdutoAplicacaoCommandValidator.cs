using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class RemoveProdutoAplicacaoCommandValidator : ProdutoCommandValidator<RemoveProdutoAplicacaoCommand>
    {
        private void ValidateAplicacaoId()
        {
            RuleFor(ap => ap.AplicacaoId)
                .NotEmpty()
                .WithMessage("O Id da aplicação não pode estar vazio.");
        }

        public RemoveProdutoAplicacaoCommandValidator()
        {
            ValidateId();
            ValidateAplicacaoId();
        }
    }
}
