using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Validators.FornecedorCommandValidators;
using System;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class UpdateFornecedorCommand : FornecedorCommand
    {
        public UpdateFornecedorCommand(Guid id, string nome, FornecedorTipoEnum tipo, string observacao)
        {
            Id = id;
            Tipo = tipo;
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
