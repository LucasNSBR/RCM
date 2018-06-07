using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class RemovedProdutoFornecedorEvent : ProdutoEvent
    {
        public Fornecedor Fornecedor { get; private set; }

        public RemovedProdutoFornecedorEvent(Produto produto, Fornecedor fornecedor) : base(produto)
        {
            Fornecedor = fornecedor;
        }

        public override void Normalize()
        {
            Args.Add("FornecedorId", Fornecedor.Id);
        }
    }
}
