using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class DevolverChequeCommandValidator : ChequeCommandValidator<DevolverChequeCommand>
    {
        public DevolverChequeCommandValidator()
        {
            ValidateId();
            ValidateDataDevolucao();
            ValidateMotivo();
        }
    }
}
