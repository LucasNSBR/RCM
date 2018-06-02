using RCM.Domain.Models.ChequeModels;

namespace RCM.Domain.Events.ChequeEvents
{
    public class UpdatedChequeEvent : ChequeEvent
    {
        public UpdatedChequeEvent(Cheque cheque) : base(cheque)
        {
        }
    }
}
