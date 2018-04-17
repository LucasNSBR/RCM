using RCM.Domain.Models.ClienteModels;
using System;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeRepassado : EstadoCheque
    {
        public Guid? ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public override EstadoChequeEnum Estado
        {
            get
            {
                return EstadoChequeEnum.Repassado;
            }
        }

        protected ChequeRepassado() { }

        public ChequeRepassado(DateTime dataEvento, Cliente cliente) : base(dataEvento)
        {
            Cliente = cliente;
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
