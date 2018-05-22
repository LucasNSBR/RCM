using RCM.Domain.Validators.EmpresaCommandValidators;

namespace RCM.Domain.Commands.EmpresaCommands
{
    public class AttachEmpresaLogoCommand : EmpresaCommand
    {
        public AttachEmpresaLogoCommand(byte[] logo)
        {
            Logo = logo;
        }

        public override bool IsValid()
        {
            ValidationResult = new AttachEmpresaLogoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
