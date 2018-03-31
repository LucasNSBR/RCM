using RCM.Domain.Validators.DuplicataCommandValidators;
using System;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class AddDuplicataCommand : DuplicataCommand
    {
        public AddDuplicataCommand(string numeroDocumento, string observacao, DateTime dataEmissao, DateTime dataVencimento, decimal valor, Guid fornecedorId, Guid? notaFiscalId)
        {
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
            ValidationResult = new AddDuplicataCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
