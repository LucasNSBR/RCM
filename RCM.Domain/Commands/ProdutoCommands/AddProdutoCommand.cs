using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AddProdutoCommand : ProdutoCommand
    {
        public AddProdutoCommand(string nome, int estoque, int estoqueMinimo, int estoqueIdeal, decimal precoVenda, Guid marcaId, string referenciaFabricante, string referenciaOriginal, string referenciaAuxiliar)
        {
            Nome = nome;
            Estoque = estoque;
            EstoqueMinimo = estoqueMinimo;
            EstoqueIdeal = estoqueIdeal;
            PrecoVenda = precoVenda;
            MarcaId = marcaId;
            ReferenciaFabricante = referenciaFabricante;
            ReferenciaOriginal = referenciaOriginal;
            ReferenciaAuxiliar = referenciaAuxiliar;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
