using RCM.Domain.Commands.MarcaCommands;

namespace RCM.Domain.Validators.MarcaCommandValidators
{
    public class UpdateMarcaCommandValidator : MarcaCommandValidator<UpdateMarcaCommand>
    {
        public UpdateMarcaCommandValidator()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
