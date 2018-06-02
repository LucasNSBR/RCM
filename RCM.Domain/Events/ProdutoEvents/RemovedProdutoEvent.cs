using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class RemovedProdutoEvent : ProdutoEvent
    {
        public RemovedProdutoEvent(Produto produto) : base(produto)
        {
        }
    }
}
