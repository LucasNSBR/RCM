using RCM.Domain.Models.ChequeModels;

namespace RCM.Domain.Events.ChequeEvents
{
    public class RemovedChequeEvent : ChequeEvent
    {
        public RemovedChequeEvent(Cheque cheque) : base(cheque)
        {
        }
    }
}
