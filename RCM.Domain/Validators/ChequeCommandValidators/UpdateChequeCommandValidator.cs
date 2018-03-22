using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class UpdateChequeCommandValidator : ChequeCommandValidator<UpdateChequeCommand>
    {
        public UpdateChequeCommandValidator()
        {
            ValidateId();
            ValidateBancoId();
            ValidateAgencia();
            ValidateConta();
            ValidateNumeroCheque();
            ValidateObservacao();
            ValidateClienteId();
            ValidateDataEmissao();
            ValidateDataVencimento();
            ValidateValor();
        }
    }
}
