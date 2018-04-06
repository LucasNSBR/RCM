using RCM.Domain.Commands.OrdemServicoCommands;

namespace RCM.Domain.Validators.OrdemServicoCommandValidators
{
    public class AddOrdemServicoCommandValidator : OrdemServicoCommandValidator<AddOrdemServicoCommand>
    {
        public AddOrdemServicoCommandValidator()
        {
            ValidateClienteId();
        }
    }
}
