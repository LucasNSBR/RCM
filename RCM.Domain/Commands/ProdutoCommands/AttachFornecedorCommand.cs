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

        public AttachFornecedorCommand(Guid id, Guid fornecedorId, decimal precoCusto, ProdutoDisponibilidadeEnum disponibilidade)
        {
            ProdutoId = id;
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
