using RCM.Domain.Validators.BancoCommandValidators;
using System;

namespace RCM.Domain.Commands.BancoCommands
{
    public class UpdateBancoCommand : BancoCommand
    {
        public UpdateBancoCommand(Guid id, string nome, int codigoCompensacao)
        {
            Id = id;
            Nome = nome;
            CodigoCompensacao = codigoCompensacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBancoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
