using RCM.Domain.Core.Commands;
using RCM.Domain.Models.DuplicataModels;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public abstract class DuplicataCommand : Command
    {
        public Duplicata Duplicata { get; }

        public DuplicataCommand(Duplicata duplicata) 
        {
            Duplicata = duplicata;
        }
    }
}
