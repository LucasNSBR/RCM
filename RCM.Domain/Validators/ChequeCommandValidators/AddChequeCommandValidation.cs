using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class AddChequeCommandValidation : ChequeCommandValidator<AddChequeCommand>
    {
        public AddChequeCommandValidation()
        {
            ValidateBancoId();
            ValidateAgencia();
            ValidateConta();
            ValidateClienteId();
            ValidateNumeroCheque();
            ValidateDataEmissao();
            ValidateDataVencimento();
            ValidateValor();
        }
    }
}
