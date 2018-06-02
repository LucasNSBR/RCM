using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Events.FornecedorEvents
{
    public class UpdatedFornecedorEvent : FornecedorEvent
    {
        public UpdatedFornecedorEvent(Fornecedor fornecedor) : base(fornecedor)
        {
        }
    }
}
