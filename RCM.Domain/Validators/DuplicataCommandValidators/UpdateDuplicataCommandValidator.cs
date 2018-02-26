using RCM.Domain.Commands.DuplicataCommands;

namespace RCM.Domain.Validators.DuplicataCommandValidations
{
    public class UpdateDuplicataCommandValidator : DuplicataCommandValidator<UpdateDuplicataCommand>
    {
        public UpdateDuplicataCommandValidator()
        {
            ValidateId();
            ValidateNumeroDocumento();
            ValidateDataEmissao();
            ValidateDataVencimento();
            ValidateValor();
        }
    }
}
