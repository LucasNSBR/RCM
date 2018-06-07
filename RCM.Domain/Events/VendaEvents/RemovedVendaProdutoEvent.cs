using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class RemovedVendaProdutoEvent : VendaEvent
    {
        public Produto Produto { get; private set; }

        public RemovedVendaProdutoEvent(Venda venda, Produto produto) : base(venda)
        {
            Produto = produto;
        }

        public override void Normalize()
        {
            Args.Add("ProdutoId", Produto.Id);
        }
    }
}
