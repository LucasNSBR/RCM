using RCM.Domain.Commands.ProdutoCommands;
using FluentValidation;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AddProdutoAplicacaoCommandValidator : ProdutoCommandValidator<AddProdutoAplicacaoCommand>
    {
        public AddProdutoAplicacaoCommandValidator()
        {
            ValidateId();
            ValidateModelo();
            ValidateMarca();
        }

        private void ValidateModelo()
        {
            RuleFor(ap => ap.ModeloCarroAplicacao)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250);
        }

        private void ValidateMotor()
        {
            RuleFor(ap => ap.MotorCarroAplicacao)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
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
