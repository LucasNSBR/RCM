using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AttachFornecedorCommand : ProdutoCommand
    {
        public decimal PrecoCusto { get; set; }
        public ProdutoDisponibilidadeEnum Disponibilidade { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid ProdutoId { get; set; }

        public AttachFornecedorCommand(Guid produtoId, Guid fornecedorId, decimal precoCusto, ProdutoDisponibilidadeEnum disponibilidade)
        {
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
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
