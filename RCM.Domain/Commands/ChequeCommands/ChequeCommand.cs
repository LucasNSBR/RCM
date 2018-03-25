using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ChequeModels;

namespace RCM.Domain.Commands.ChequeCommands
{
    public abstract class ChequeCommand : Command
    {
        public Cheque Cheque { get; }

        public ChequeCommand(Cheque cheque) 
        {
            Cheque = cheque;
        }
    }
}
