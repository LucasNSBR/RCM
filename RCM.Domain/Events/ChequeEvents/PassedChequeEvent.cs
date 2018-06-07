using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Events.ChequeEvents
{
    public class PassedChequeEvent : ChequeEvent
    {
        public ChequeRepassado ChequeRepassado { get; private set; }
        public Fornecedor Fornecedor { get; private set; }

        public PassedChequeEvent(Cheque cheque, EstadoCheque chequeRepassado, Fornecedor fornecedor) : base(cheque)
        {
            ChequeRepassado = chequeRepassado as ChequeRepassado;
            Fornecedor = fornecedor;
        }

        public override void Normalize()
        {
            Args.Add(nameof(ChequeRepassado.DataEvento), ChequeRepassado.DataEvento);
            Args.Add("Id do Fornecedor", ChequeRepassado.FornecedorId);
            Args.Add("Nome do Fornecedor", Fornecedor.Nome);
        }
    }
}
