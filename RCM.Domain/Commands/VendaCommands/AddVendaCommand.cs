using RCM.Domain.Validators.VendaCommandValidators;
using System;

namespace RCM.Domain.Commands.VendaCommands
{
    public class AddVendaCommand : VendaCommand
    {
        public AddVendaCommand(DateTime dataVenda, string detalhes, Guid clienteId)
        {
            DataVenda = dataVenda;
            Detalhes = detalhes;
            ClienteId = clienteId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
