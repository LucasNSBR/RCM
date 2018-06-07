using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;

namespace RCM.Domain.Events.ChequeEvents
{
    public class PaidChequeEvent : ChequeEvent
    {
        public ChequeCompensado ChequeCompensado { get; private set; }

        public PaidChequeEvent(Cheque cheque, EstadoCheque estadoCheque) : base(cheque)
        {
            ChequeCompensado = estadoCheque as ChequeCompensado;
        }

        public override void Normalize()
        {
            Args.Add(nameof(ChequeCompensado.DataEvento), ChequeCompensado.DataEvento);
        }
    }
}
