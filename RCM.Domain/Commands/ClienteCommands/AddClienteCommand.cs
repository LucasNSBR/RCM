using RCM.Domain.Validators.ClienteCommandValidators;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class AddClienteCommand : ClienteCommand
    {
        public AddClienteCommand(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
