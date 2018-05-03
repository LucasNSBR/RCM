using RCM.Domain.Commands.EmpresaCommands;

namespace RCM.Domain.Validators.EmpresaCommandValidators
{
    public class AddOrUpdateEmpresaCommandValidator : EmpresaCommandValidator<AddOrUpdateEmpresaCommand>
    {
        public AddOrUpdateEmpresaCommandValidator()
        {
            ValidateRazaoSocial();
            ValidateNomeFantasia();
            ValidateDescricao();
            ValidateContato();
            ValidateEndereco();
            ValidateDocumento();
        }
    }
}
