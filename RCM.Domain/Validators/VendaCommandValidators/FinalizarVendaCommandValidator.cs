using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class FinalizarVendaCommandValidator : VendaCommandValidator<FinalizarVendaCommand>
    {
        public FinalizarVendaCommandValidator()
        {
            ValidateVendaId();
        }
    }
}
