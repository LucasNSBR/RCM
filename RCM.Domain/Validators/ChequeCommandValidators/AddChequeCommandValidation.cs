using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class AddChequeCommandValidation : ChequeCommandValidator<AddChequeCommand>
    {
        AddChequeCommandValidation()
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
