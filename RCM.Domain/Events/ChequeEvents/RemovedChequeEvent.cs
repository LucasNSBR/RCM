using RCM.Domain.Models.ChequeModels;

namespace RCM.Domain.Events.ChequeEvents
{
    public class RemovedChequeEvent : ChequeEvent
    {
        public RemovedChequeEvent(Cheque cheque) : base(cheque)
        {
        }

        public override void Normalize()
        {
            Args.Add(nameof(Cheque.Id), Cheque.Id);
        }
    }
}
