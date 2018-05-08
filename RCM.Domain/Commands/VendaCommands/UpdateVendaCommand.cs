using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class UpdateVendaCommand : VendaCommand
    {
        public UpdateVendaCommand(Guid id, DateTime dataVenda, string detalhes, Guid clienteId)
        {
            VendaId = id;
            DataVenda = dataVenda;
            Detalhes = detalhes;
            ClienteId = clienteId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
