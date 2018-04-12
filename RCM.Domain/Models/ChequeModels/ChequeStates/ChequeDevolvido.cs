namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeDevolvido : EstadoCheque
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
        }

        public override void Repassar(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeRepassado());
        }

        public override void Sustar(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeSustado());
        }
    }
}
