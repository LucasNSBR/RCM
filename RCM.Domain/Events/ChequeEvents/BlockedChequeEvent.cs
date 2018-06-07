using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;

namespace RCM.Domain.Events.ChequeEvents
{
    public class BlockedChequeEvent : ChequeEvent
    {
        public ChequeBloqueado ChequeBloqueado { get; private set; }

        public BlockedChequeEvent(Cheque cheque, EstadoCheque estadoCheque) : base(cheque)
        {
            ChequeBloqueado = estadoCheque as ChequeBloqueado;
        }

        public override void Normalize()
        {
            Args.Add(nameof(ChequeBloqueado.DataEvento), ChequeBloqueado.DataEvento);
        }
    }
}
