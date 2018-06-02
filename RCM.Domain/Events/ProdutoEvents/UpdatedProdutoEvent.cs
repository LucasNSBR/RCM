
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public class UpdatedProdutoEvent : ProdutoEvent
    {
        public UpdatedProdutoEvent(Produto produto) : base(produto)
        {
        }
    }
}
