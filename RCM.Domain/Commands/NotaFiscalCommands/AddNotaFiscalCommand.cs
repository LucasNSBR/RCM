using RCM.Domain.Validators.NotaFiscalCommandValidators;
using System;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class AddNotaFiscalCommand : NotaFiscalCommand
    {
        public AddNotaFiscalCommand(string numeroDocumento, DateTime dataEmissao, decimal valor, DateTime? dataChegada = null)
        {
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            Valor = valor;
            dataChegada = dataChegada ?? dataEmissao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNotaFiscalCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
