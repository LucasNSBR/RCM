using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AddProdutoCommand : ProdutoCommand
    {
        public AddProdutoCommand(string nome, int quantidade, decimal precoVenda, Guid marcaId)
        {
            Nome = nome;
            Quantidade = quantidade;
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
