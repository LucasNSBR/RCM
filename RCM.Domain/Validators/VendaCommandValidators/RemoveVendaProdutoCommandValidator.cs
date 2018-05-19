using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class RemoveVendaProdutoCommandValidator : VendaCommandValidator<RemoveVendaProdutoCommand>
    {
        public RemoveVendaProdutoCommandValidator()
        {
            ValidateProdutoId();
        }

        private void ValidateProdutoId()
        {
            RuleFor(pv => pv.ProdutoId)
                .NotEmpty();
        }
    }
}
