using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;

namespace RCM.Domain.Events.ChequeEvents
{
    public class RefundedChequeEvent : ChequeEvent
    {
        public ChequeDevolvido ChequeDevolvido { get; private set; }

        public RefundedChequeEvent(Cheque cheque, EstadoCheque chequeDevolvido) : base(cheque)
        {
            ChequeDevolvido = chequeDevolvido as ChequeDevolvido;
        }

        public override void Normalize()
        {
            Args.Add(nameof(ChequeDevolvido.DataEvento), ChequeDevolvido.DataEvento);
            Args.Add(nameof(ChequeDevolvido.Motivo), ChequeDevolvido.Motivo);
        }
    }
}
