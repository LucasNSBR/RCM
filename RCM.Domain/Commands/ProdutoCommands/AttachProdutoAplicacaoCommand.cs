using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AttachProdutoAplicacaoCommand : ProdutoCommand
    {
        public Guid AplicacaoId { get; set; }

        public AttachProdutoAplicacaoCommand(Guid produtoId, Guid aplicacaoId)
        {
            Id = produtoId;
            AplicacaoId = aplicacaoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AttachProdutoAplicacaoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
