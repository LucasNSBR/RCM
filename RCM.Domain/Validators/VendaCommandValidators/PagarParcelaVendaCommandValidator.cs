using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class PagarParcelaVendaCommandValidator : VendaCommandValidator<PagarParcelaVendaCommand>
    {
        public PagarParcelaVendaCommandValidator()
        {
            ValidateVendaId();
        }

        public void ValidateParcelaId()
        {
            RuleFor(v => v.ParcelaId)
                .ExclusiveBetween(0, 7);
        }
    }
}
