using RCM.Domain.Models.FornecedorModels;
using System;

namespace RCM.Domain.Models.ChequeModels.ChequeStates
{
    public class ChequeRepassado : EstadoCheque
    {
        public Guid? FornecedorId { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }
        public override EstadoChequeEnum Estado
        {
            get
            {
                return EstadoChequeEnum.Repassado;
            }
        }

        protected ChequeRepassado() { }

        public ChequeRepassado(DateTime dataEvento, Fornecedor fornecedor) : base(dataEvento)
        {
            Fornecedor = fornecedor;
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
