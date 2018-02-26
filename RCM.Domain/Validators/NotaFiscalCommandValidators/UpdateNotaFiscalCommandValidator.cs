using RCM.Domain.Commands.NotaFiscalCommands;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public class UpdateNotaFiscalCommandValidator : NotaFiscalCommandValidator<UpdateNotaFiscalCommand>
    {
        public UpdateNotaFiscalCommandValidator()
        {
            ValidateId();
            ValidateNumeroDocumento();
            ValidateDataEmissao();
            ValidateDataChegada();
            ValidateValor();
        }
    }
}
