using RCM.Domain.Validators.DuplicataCommandValidators;
using System;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class UpdateDuplicataCommand : DuplicataCommand
    {
        public UpdateDuplicataCommand(Guid id, string numeroDocumento, string observacao, DateTime dataEmissao, DateTime dataVencimento, decimal valor, Guid fornecedorId, Guid? notaFiscalId)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            Observacao = observacao;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Valor = valor;
            FornecedorId = fornecedorId;
            NotaFiscalId = notaFiscalId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
