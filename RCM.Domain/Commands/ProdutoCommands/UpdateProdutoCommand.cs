using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class UpdateProdutoCommand : ProdutoCommand
    {
        public UpdateProdutoCommand(Guid id, string nome, int estoque, decimal precoVenda, Guid marcaId)
        {
            Id = id;
            Nome = nome;
            Estoque = estoque;
            PrecoVenda = precoVenda;
            MarcaId = marcaId;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
