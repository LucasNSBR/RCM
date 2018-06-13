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

        protected void ValidateEstoqueIdeal()
        {
            RuleFor(p => p.EstoqueIdeal)
                .Must((command, property) =>
                {
                    return command.EstoqueIdeal > command.EstoqueMinimo;
                })
                .WithMessage("O estoque ideal deve ser maior que o estoque mínimo.");
        }

        protected void ValidatePrecoVenda()
        {
            RuleFor(p => p.PrecoVenda)
                .NotEmpty();
        }
    }
}
