using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AttachFornecedorCommand : ProdutoCommand
    {
        public string ReferenciaFornecedor { get; set; }
        public decimal PrecoCusto { get; set; }
        public ProdutoDisponibilidadeEnum Disponibilidade { get; set; }
        public Guid FornecedorId { get; set; }

        public AttachFornecedorCommand(Guid id, Guid fornecedorId, string referenciaFornecedor, decimal precoCusto, ProdutoDisponibilidadeEnum disponibilidade)
        {
            ProdutoId = id;
            FornecedorId = fornecedorId;
            ReferenciaFornecedor = referenciaFornecedor;
            PrecoCusto = precoCusto;
            Disponibilidade = disponibilidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new AttachFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
