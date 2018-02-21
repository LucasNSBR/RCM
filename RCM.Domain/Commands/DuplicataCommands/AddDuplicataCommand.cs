using RCM.Domain.Models;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class AddDuplicataCommand : DuplicataCommand
    {
        public AddDuplicataCommand(Duplicata duplicata) : base(duplicata)
        {
        }
    }
}
