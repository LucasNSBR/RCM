using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class RemoveProdutoFornecedorCommand : ProdutoCommand
    {
        public Guid FornecedorId { get; set; }

        public RemoveProdutoFornecedorCommand(Guid produtoId, Guid fornecedorId)
        {
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProdutoFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
