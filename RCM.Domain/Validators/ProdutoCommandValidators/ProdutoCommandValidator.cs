using FluentValidation;
using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class ProdutoCommandValidator<T> : AbstractValidator<T> where T : ProdutoCommand 
    {
        protected void ValidateId()
        {
            RuleFor(p => p.ProdutoId)
                .NotEmpty()
                .WithMessage("O Id do produto não pode estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto deve ter entre 5 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateUnidade()
        {
            RuleFor(p => p.Unidade)
                .NotEmpty()
                .WithMessage("O tipo de unidade não pode estar vazio.");
        }

        protected void ValidateEstoque()
        {
            RuleFor(p => p.Estoque)
                .NotEmpty()
                .WithMessage("O estoque do produto não deve estar vazio.");
        }

        protected void ValidatePrecoVenda()
        {
            RuleFor(p => p.PrecoVenda)
                .NotEmpty()
                .WithMessage("O preço de venda do produto não deve estar vazio.");
        }
    }
}
