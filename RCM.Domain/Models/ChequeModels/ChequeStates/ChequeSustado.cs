namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeSustado : EstadoCheque
    {
        public override void Bloquear(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeBloqueado());
        }

        public override void Compensar(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeRepassado());
        }

        public override void Devolvido(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeDevolvido());
        }

        public override void Repassar(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeSustado());
        }

        public override void Sustar(Cheque cheque)
        {
        }
    }
}
