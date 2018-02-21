using RCM.Domain.Models;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class UpdateChequeCommand : ChequeCommand
    {
        public UpdateChequeCommand(Cheque cheque) : base(cheque)
        {
        }
    }
}
