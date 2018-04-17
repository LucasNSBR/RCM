using RCM.Domain.Commands.MarcaCommands;

namespace RCM.Domain.Validators.MarcaCommandValidators
{
    public class AddMarcaCommandValidator : MarcaCommandValidator<AddMarcaCommand>
    {
        public AddMarcaCommandValidator()
        {
            ValidateNome();
        }
    }
}
