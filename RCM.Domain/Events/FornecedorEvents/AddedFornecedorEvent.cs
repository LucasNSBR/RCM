using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Events.FornecedorEvents
{
    public class AddedFornecedorEvent : FornecedorEvent
    {
        public AddedFornecedorEvent(Fornecedor fornecedor) : base(fornecedor)
        {
        }
    }
}
