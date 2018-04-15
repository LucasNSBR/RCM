using System;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeCompensado : EstadoCheque
    {
        public override string Estado
        {
            get
            {
                return "Compensado";
            }
        }

        protected ChequeCompensado() { }

        public ChequeCompensado(DateTime dataEvento) : base(dataEvento)
        {
        }

        public override void Bloquear(Cheque cheque)
        {
            cheque.MudarEstado(new ChequeBloqueado());
        }

        public override void Compensar(Cheque cheque, DateTime dataEvento)
        {
            cheque.MudarEstado(new ChequeCompensado(dataEvento));
        }

        public override void Repassar(Cheque cheque, DateTime dataEvento, Cliente cliente)
        {
            cheque.MudarEstado(new ChequeRepassado(dataEvento, cliente));
        }

        public override void Sustar(Cheque cheque, DateTime dataEvento, string motivo)
        {
            cheque.MudarEstado(new ChequeSustado(dataEvento, motivo));
        }

        public override void Devolver(Cheque cheque, DateTime dataEvento, string motivo)
        {
            cheque.MudarEstado(new ChequeDevolvido(dataEvento, motivo));
        }
    }
}
