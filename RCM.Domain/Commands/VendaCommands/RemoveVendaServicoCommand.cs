using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class RemoveVendaServicoCommand : VendaCommand
    {
        public Guid ServicoId { get; set; }

        public RemoveVendaServicoCommand(Guid vendaId, Guid servicoId)
        {
            VendaId = vendaId;
            ServicoId = servicoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveVendaServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
