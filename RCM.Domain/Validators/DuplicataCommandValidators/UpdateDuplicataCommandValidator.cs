using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validators.DuplicataCommandValidators
{
    public class UpdateDuplicataCommandValidator : DuplicataCommandValidator<UpdateDuplicataCommand>
    {
        public UpdateDuplicataCommandValidator()
        {
            ValidateId();
            ValidateNumeroDocumento();
            ValidateObservacao();
            ValidateDataEmissao();
            ValidateDataVencimento();
            ValidateNotaFiscalId();
            ValidateValor();
        }
    }
}
