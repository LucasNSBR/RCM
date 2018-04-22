using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AttachProdutoAplicacaoCommandValidator : ProdutoCommandValidator<AttachProdutoAplicacaoCommand>
    {
        private void ValidateAplicacaoId()
        {
            RuleFor(ap => ap.AplicacaoId)
                .NotEmpty()
                .WithMessage("O Id da aplicação não pode estar vazio.");
        }

        public AttachProdutoAplicacaoCommandValidator()
        {
            ValidateId();
            ValidateAplicacaoId();
        }
    }
}
