using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class RemoveVendaProdutoCommand : VendaCommand
    {
        public Guid ProdutoId { get; set; }

        public RemoveVendaProdutoCommand(Guid vendaId, Guid produtoId)
        {
            Id = vendaId;
            ProdutoId = produtoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveVendaProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
