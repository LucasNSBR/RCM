using RCM.Domain.Models.ChequeModels;

namespace RCM.Domain.Events.ChequeEvents
{
    public class AddedChequeEvent : ChequeEvent
    {
        public AddedChequeEvent(Cheque cheque) : base(cheque)
        {
        }
    }
}
