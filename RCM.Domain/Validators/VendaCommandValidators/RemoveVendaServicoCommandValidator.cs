using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class RemoveVendaServicoCommandValidator : VendaCommandValidator<RemoveVendaServicoCommand>
    {
        public RemoveVendaServicoCommandValidator()
        {
            ValidateVendaId();
            ValidateServicoId();
        }

        private void ValidateServicoId()
        {
            RuleFor(s => s)
                .NotEmpty();
        }
    }
}
