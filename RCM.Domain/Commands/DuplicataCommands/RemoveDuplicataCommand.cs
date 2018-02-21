using RCM.Domain.Models;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public class RemoveDuplicataCommand : DuplicataCommand
    {
        public RemoveDuplicataCommand(Duplicata duplicata) : base(duplicata)
        {
        }
    }
}
