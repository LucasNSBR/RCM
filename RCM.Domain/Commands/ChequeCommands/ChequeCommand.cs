using RCM.Domain.Core.Command;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.ChequeCommands
{
    public abstract class ChequeCommand : Command
    {
        public Cheque Cheque { get; private set; }

        public ChequeCommand(Cheque cheque)
        {
            Cheque = cheque;
        }
    }
}
