using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class UpdateProdutoCommand : ProdutoCommand
    {
        public UpdateProdutoCommand(Guid id, string nome, string aplicacao, int quantidade, decimal precoVenda, Guid marcaId)
        {
            Id = id;
            Nome = nome;
            Aplicacao = aplicacao;
            Quantidade = quantidade;
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
