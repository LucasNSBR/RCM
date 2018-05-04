using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class AddVendaCommandValidator : VendaCommandValidator<AddVendaCommand>
    {
        public AddVendaCommandValidator()
        {
            ValidateDataVenda();
            ValidateDetalhes();
            ValidateClienteId();
        }
    }
}
