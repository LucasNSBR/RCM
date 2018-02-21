using RCM.Domain.Models;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class AddChequeCommand : ChequeCommand
    {
        public AddChequeCommand(Cheque cheque) : base(cheque)
        {
        }
    }
}
