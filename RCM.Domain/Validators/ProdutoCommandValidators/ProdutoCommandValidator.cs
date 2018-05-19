using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class ProdutoCommandValidator<T> : AbstractValidator<T> where T : ProdutoCommand 
    {
        protected void ValidateId()
        {
            RuleFor(p => p.ProdutoId)
                .NotEmpty();
        }

        protected void ValidateNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty();
        }

        protected void ValidateUnidade()
        {
            RuleFor(p => p.Unidade)
                .NotEmpty();
        }

        protected void ValidateEstoque()
        {
            RuleFor(p => p.Estoque)
                .NotEmpty();
        }

        protected void ValidatePrecoVenda()
        {
            RuleFor(p => p.PrecoVenda)
                .NotEmpty();
        }
    }
}
