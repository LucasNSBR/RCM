namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public abstract class EstadoCheque
    {
        public abstract void Compensar(Cheque cheque);
        public abstract void Bloquear(Cheque cheque);
        public abstract void Sustar(Cheque cheque);
        public abstract void Repassar(Cheque cheque);
        public abstract void Devolvido(Cheque cheque);
    }
}