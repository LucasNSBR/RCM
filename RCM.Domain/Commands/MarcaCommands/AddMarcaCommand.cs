using RCM.Domain.Validators.MarcaCommandValidators;

namespace RCM.Domain.Commands.MarcaCommands
{
    public class AddMarcaCommand : MarcaCommand
    {
        public AddMarcaCommand(string nome, string observacao)
        {
            Nome = nome;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddMarcaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
