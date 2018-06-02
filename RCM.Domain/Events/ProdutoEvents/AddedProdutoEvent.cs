using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class AddedProdutoEvent : ProdutoEvent
    {
        public AddedProdutoEvent(Produto produto) : base(produto)
        {
        }
    }
}
