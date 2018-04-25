using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AddProdutoCommand : ProdutoCommand
    {
        public AddProdutoCommand(string nome, int estoque, decimal precoVenda, Guid marcaId)
        {
            Nome = nome;
            Estoque = estoque;
            PrecoVenda = precoVenda;
            MarcaId = marcaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
