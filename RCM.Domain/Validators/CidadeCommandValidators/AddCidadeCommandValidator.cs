using RCM.Domain.Commands.CidadeCommands;

namespace RCM.Domain.Validators.CidadeCommandValidators
{
    public class AddCidadeCommandValidator : CidadeCommandValidator<AddCidadeCommand>
    {
        public AddCidadeCommandValidator()
        {
            ValidateNome();
        }
    }
}
