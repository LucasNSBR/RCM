using RCM.Domain.Models;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class RemoveChequeCommand : ChequeCommand
    {
        public RemoveChequeCommand(Cheque cheque) : base(cheque)
        {
        }
    }
}
