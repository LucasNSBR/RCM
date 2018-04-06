using RCM.Domain.Commands.OrdemServicoCommands;

namespace RCM.Domain.Validators.OrdemServicoCommandValidators
{
    public class RemoveOrdemServicoCommandValidator : OrdemServicoCommandValidator<RemoveOrdemServicoCommand>
    {
        public RemoveOrdemServicoCommandValidator()
        {
            ValidateId();
        }
    }
}
