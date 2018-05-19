using RCM.Domain.Commands.ProdutoCommands;
using FluentValidation;
using System;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AddProdutoAplicacaoCommandValidator : ProdutoCommandValidator<AddProdutoAplicacaoCommand>
    {
        public AddProdutoAplicacaoCommandValidator()
        {
            ValidateId();
            ValidateAno();
            ValidateModelo();
            ValidateMarca();
        }

        private void ValidateAno()
        {
            RuleFor(ap => ap.AnoCarroAplicacao)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.AddYears(-30).Year);
        }

        private void ValidateModelo()
        {
            RuleFor(ap => ap.ModeloCarroAplicacao)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250);
        }

        private void ValidateMarca()
        {
            RuleFor(ap => ap.MarcaCarroAplicacao)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}
