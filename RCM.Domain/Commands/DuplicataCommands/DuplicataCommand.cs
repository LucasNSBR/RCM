using RCM.Domain.Core.Commands;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public abstract class DuplicataCommand : Command
    {
        public Duplicata Duplicata { get; private set; }

        public DuplicataCommand(Duplicata duplicata) 
        {
            Duplicata = duplicata;
        }
    }
}
