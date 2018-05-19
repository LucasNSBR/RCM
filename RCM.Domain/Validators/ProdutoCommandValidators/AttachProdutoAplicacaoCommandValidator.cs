using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AttachProdutoAplicacaoCommandValidator : ProdutoCommandValidator<AttachProdutoAplicacaoCommand>
    {
        public AttachProdutoAplicacaoCommandValidator()
        {
            ValidateId();
            ValidateAplicacaoId();
        }

        private void ValidateAplicacaoId()
        {
            RuleFor(ap => ap.AplicacaoId)
                .NotEmpty();
        }
    }
}
