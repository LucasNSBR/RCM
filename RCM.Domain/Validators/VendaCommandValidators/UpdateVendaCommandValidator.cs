using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class UpdateVendaCommandValidator : VendaCommandValidator<UpdateVendaCommand>
    {
        public UpdateVendaCommandValidator()
        {
            ValidateId();
            ValidateDataVenda();
            ValidateDetalhes();
            ValidateClienteId();
        }
    }
}
