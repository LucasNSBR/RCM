using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class RemoveProdutoAplicacaoCommand : ProdutoCommand
    {
        public Guid AplicacaoId { get; set; }

        public RemoveProdutoAplicacaoCommand(Guid produtoId, Guid produtoAplicacaoId)
        {
            Id = produtoId;
            AplicacaoId = produtoAplicacaoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProdutoAplicacaoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
