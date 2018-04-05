using RCM.Domain.Validators.FornecedorCommandValidators;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class AddFornecedorCommand : FornecedorCommand
    {
        public AddFornecedorCommand(string nome, string observacao)
        {
            Nome = nome;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
