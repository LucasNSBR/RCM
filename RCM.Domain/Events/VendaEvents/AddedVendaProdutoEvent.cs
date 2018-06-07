using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class AddedVendaProdutoEvent : VendaEvent
    {
        public Produto Produto { get; private set; }

        public AddedVendaProdutoEvent(Venda venda, Produto produto) : base(venda)
        {
            Produto = produto;
        }

        public override void Normalize()
        {
            Args.Add("ProdutoId", Produto.Id);
            Args.Add(nameof(Produto.Nome), Produto.Nome);
            Args.Add(nameof(Produto.ReferenciaFabricante), Produto.ReferenciaFabricante);
            Args.Add(nameof(Produto.ReferenciaOriginal), Produto.ReferenciaOriginal);
            Args.Add(nameof(Produto.ReferenciaAuxiliar), Produto.ReferenciaAuxiliar);
            Args.Add("MarcaId", Produto.MarcaId);
            Args.Add(nameof(Produto.PrecoVenda), Produto.PrecoVenda);
        }
    }
}
