using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class AttachVendaProdutoCommand : VendaCommand
    {
        public Guid VendaId { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public int Quantidade { get; set; }

        public AttachVendaProdutoCommand(Guid vendaId, Guid produtoId, decimal precoVenda, decimal desconto, decimal acrescimo, int quantidade)
        {
            VendaId = vendaId;
            ProdutoId = produtoId;
            PrecoVenda = precoVenda;
            Desconto = desconto;
            Acrescimo = acrescimo;
            Quantidade = quantidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new AttachVendaProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
