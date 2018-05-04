using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class RemoveVendaCommandValidator : VendaCommandValidator<RemoveVendaCommand>
    {
        public RemoveVendaCommandValidator()
        {
            ValidateId();
        }
    }
}
