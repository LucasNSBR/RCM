using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class AddChequeCommandValidator : ChequeCommandValidator<AddChequeCommand>
    {
        public AddChequeCommandValidator()
        {
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
