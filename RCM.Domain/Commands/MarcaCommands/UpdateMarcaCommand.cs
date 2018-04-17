using RCM.Domain.Validators.MarcaCommandValidators;
using System;

namespace RCM.Domain.Commands.MarcaCommands
{
    public class UpdateMarcaCommand : MarcaCommand
    {
        public UpdateMarcaCommand(Guid id, string nome, string observacao)
        {
            Id = id;
            Nome = nome;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateMarcaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
