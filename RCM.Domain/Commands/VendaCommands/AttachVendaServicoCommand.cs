using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class AttachVendaServicoCommand : VendaCommand
    {
        public string ServicoDetalhes { get; set; }
        public decimal ServicoPreco { get; set; }

        public AttachVendaServicoCommand(Guid vendaId, string detalhes, decimal precoServico)
        {
            VendaId = vendaId;
            ServicoDetalhes = detalhes;
            ServicoPreco = precoServico;
        }

        public override bool IsValid()
        {
            ValidationResult = new AttachVendaServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
