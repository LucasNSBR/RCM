using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;

namespace RCM.Domain.Events.ChequeEvents
{
    public class CanceledChequeEvent : ChequeEvent
    {
        public ChequeSustado ChequeSustado { get; private set; }

        public CanceledChequeEvent(Cheque cheque, EstadoCheque chequeSustado) : base(cheque)
        {
            ChequeSustado = chequeSustado as ChequeSustado;
        }

        public override void Normalize()
        {
            Args.Add(nameof(ChequeSustado.DataEvento), ChequeSustado.DataEvento);
            Args.Add(nameof(ChequeSustado.Motivo), ChequeSustado.Motivo);
        }
    }
}
