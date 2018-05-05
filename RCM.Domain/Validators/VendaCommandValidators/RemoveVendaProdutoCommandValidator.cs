using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class RemoveVendaProdutoCommandValidator : VendaCommandValidator<RemoveVendaProdutoCommand>
    {
        private void ValidateProdutoId()
        {
            RuleFor(pv => pv.ProdutoId)
                .NotEmpty()
                .WithMessage("O Id do produto não pode estar vazio.");
        }

        public RemoveVendaProdutoCommandValidator()
        {
            ValidateProdutoId();
        }
    }
}
