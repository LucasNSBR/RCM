using RCM.Domain.Validators.NotaFiscalCommandValidators;
using System;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class UpdateNotaFiscalCommand : NotaFiscalCommand
    {
        public UpdateNotaFiscalCommand(Guid id, string numeroDocumento, DateTime dataEmissao, decimal valor, DateTime? dataChegada = null)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            Valor = valor;
            DataChegada = dataChegada ?? dataEmissao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateNotaFiscalCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
