using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Validators.FornecedorCommandValidators;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class AddFornecedorCommand : FornecedorCommand
    {
        public AddFornecedorCommand(string nome, FornecedorTipoEnum tipo, string observacao)
        {
            Nome = nome;
            Tipo = tipo;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
