using RCM.Domain.Commands.EmpresaCommands;

namespace RCM.Domain.Validators.EmpresaCommandValidators
{
    public class AttachEmpresaLogoCommandValidator : EmpresaCommandValidator<AttachEmpresaLogoCommand>
    {
        public AttachEmpresaLogoCommandValidator()
        {
            ValidateLogo();
        }
    }
}
