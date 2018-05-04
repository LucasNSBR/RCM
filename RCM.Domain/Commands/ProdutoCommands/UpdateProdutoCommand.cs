using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class UpdateProdutoCommand : ProdutoCommand
    {
        public UpdateProdutoCommand(Guid id, string nome, ProdutoUnidadeEnum unidade, int estoque, int estoqueMinimo, int estoqueIdeal, decimal precoVenda, Guid marcaId, string referenciaFabricante, string referenciaOriginal, string referenciaAuxiliar)
        {
            ProdutoId = id;
            Nome = nome;
            Unidade = unidade;
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
            ValidationResult = new UpdateProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
