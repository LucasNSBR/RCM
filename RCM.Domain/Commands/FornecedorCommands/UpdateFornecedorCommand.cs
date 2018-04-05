using RCM.Domain.Validators.FornecedorCommandValidators;
using System;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class UpdateFornecedorCommand : FornecedorCommand
    {
        public UpdateFornecedorCommand(Guid id, string nome, string observacao)
        {
            Id = id;
            Nome = nome;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
