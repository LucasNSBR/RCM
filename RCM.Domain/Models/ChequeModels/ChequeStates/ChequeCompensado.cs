using System;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeCompensado : EstadoCheque
    {
        public override EstadoChequeEnum Estado
        {
            get
            {
                return EstadoChequeEnum.Compensado;
            }
        }

        protected ChequeCompensado() { }

        public ChequeCompensado(DateTime dataEvento) : base(dataEvento)
        {
        }

        public override void Bloquear(Cheque cheque, DateTime dataEvento)
        {
            cheque.MudarEstado(new ChequeBloqueado(dataEvento));
        }

        public override void Compensar(Cheque cheque, DateTime dataEvento)
        {
            cheque.MudarEstado(new ChequeCompensado(dataEvento));
        }

        public override void Repassar(Cheque cheque, DateTime dataEvento, Fornecedor fornecedor)
        {
            cheque.MudarEstado(new ChequeRepassado(dataEvento, fornecedor));
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
