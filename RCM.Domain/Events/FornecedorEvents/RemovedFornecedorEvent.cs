using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Events.FornecedorEvents
{
    public class RemovedFornecedorEvent : FornecedorEvent
    {
        public RemovedFornecedorEvent(Fornecedor fornecedor) : base(fornecedor)
        {
        }
    }
}
