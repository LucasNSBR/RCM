using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validators.DuplicataCommandValidators
{
    public class AddDuplicataCommandValidator : DuplicataCommandValidator<AddDuplicataCommand>
    {
        public AddDuplicataCommandValidator() 
        {
            ValidateNumeroDocumento();
            ValidateObservacao();
            ValidateDataEmissao();
            ValidateDataVencimento();
            ValidateNotaFiscalId();
            ValidateValor();
        }
    }
}
