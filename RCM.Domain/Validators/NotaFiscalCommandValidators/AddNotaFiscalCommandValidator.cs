using RCM.Domain.Commands.NotaFiscalCommands;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public class AddNotaFiscalCommandValidator : NotaFiscalCommandValidator<NotaFiscalCommand>
    {
        public AddNotaFiscalCommandValidator()
        {
            ValidateNumeroDocumento();
            ValidateDataEmissao();
            ValidateDataChegada();
            ValidateValor();
        }
    }
}
