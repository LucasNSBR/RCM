using RCM.Domain.Validators.BancoCommandValidators;

namespace RCM.Domain.Commands.BancoCommands
{
    public class AddBancoCommand : BancoCommand
    {
        public AddBancoCommand(string nome, int codigoCompensacao)
        {
            Nome = nome;
            CodigoCompensacao = codigoCompensacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddBancoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
