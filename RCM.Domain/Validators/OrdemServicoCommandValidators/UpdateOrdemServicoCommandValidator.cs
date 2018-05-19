using RCM.Domain.Commands.OrdemServicoCommands;

namespace RCM.Domain.Validators.OrdemServicoCommandValidators
{
    public class UpdateOrdemServicoCommandValidator : OrdemServicoCommandValidator<UpdateOrdemServicoCommand>
    {
        public UpdateOrdemServicoCommandValidator()
        {
            ValidateId();
            ValidateClienteId();
            ValidateDataEntrada();
        }
    }
}
