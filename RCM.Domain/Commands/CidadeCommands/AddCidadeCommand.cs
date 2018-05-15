using RCM.Domain.Validators.CidadeCommandValidators;
using System;

namespace RCM.Domain.Commands.CidadeCommands
{
    public class AddCidadeCommand : CidadeCommand
    {
        public AddCidadeCommand(string nome, Guid estadoId)
        {
            Nome = nome;
            EstadoId = estadoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddCidadeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
