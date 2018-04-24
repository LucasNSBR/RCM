using RCM.Domain.Commands.ProdutoCommands;
using FluentValidation;
using System;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AddProdutoAplicacaoCommandValidator : ProdutoCommandValidator<AddProdutoAplicacaoCommand>
    {
        private void ValidateAno()
        {
            RuleFor(ap => ap.AnoCarroAplicacao)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddYears(-30).Year)
                .WithMessage("O ano da aplicação deve estar em um formato válido.");
        }

        private void ValidateModelo()
        {
            RuleFor(ap => ap.ModeloCarroAplicacao)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250)
                .WithMessage("O modelo da aplicação deve ter entre 3 e 250 caracteres e não pode estar vazio.");
        }

        private void ValidateMarca()
        {
            RuleFor(ap => ap.MarcaCarroAplicacao)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .WithMessage("A marca deve ter entre 2 e 100 caracteres e não pode estar vazio.");
        }

        public AddProdutoAplicacaoCommandValidator()
        {
            ValidateId();
            ValidateAno();
            ValidateModelo();
            ValidateMarca();
        }
    }
}
