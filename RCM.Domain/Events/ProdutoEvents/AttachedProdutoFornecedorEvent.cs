using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class AttachedProdutoFornecedorEvent : ProdutoEvent
    {
        public Fornecedor Fornecedor { get; private set; }

        public AttachedProdutoFornecedorEvent(Produto produto, Fornecedor fornecedor) : base(produto)
        {
            Fornecedor = fornecedor;
        }

        public override void Normalize()
        {
            Args.Add(nameof(Fornecedor.Nome), Fornecedor.Nome);
            Args.Add("FornecedorId", Fornecedor.Id);
        }
    }
}
