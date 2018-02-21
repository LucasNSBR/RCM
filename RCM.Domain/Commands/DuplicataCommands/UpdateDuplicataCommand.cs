using RCM.Domain.Models;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class UpdateDuplicataCommand : DuplicataCommand
    {
        public UpdateDuplicataCommand(Duplicata duplicata) : base(duplicata)
        {
        }
    }
}
