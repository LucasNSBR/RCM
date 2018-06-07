using RCM.Domain.Core.Events;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Events.ProdutoEvents
{
    public abstract class ProdutoEvent : DomainEvent
    {
        public Produto Produto { get; set; }

        public ProdutoEvent(Produto produto)
        {
            Produto = produto;
            AggregateId = Produto.Id;
        }

        public override void Normalize()
        {
            Args.Add(nameof(Produto.Nome), Produto.Nome);
            Args.Add(nameof(Produto.Unidade), Produto.Unidade);
            Args.Add(nameof(Produto.ReferenciaFabricante), Produto.ReferenciaFabricante);
            Args.Add(nameof(Produto.ReferenciaOriginal), Produto.ReferenciaOriginal);
            Args.Add(nameof(Produto.ReferenciaAuxiliar), Produto.ReferenciaAuxiliar);
            Args.Add(nameof(Produto.Estoque), Produto.Estoque);
            Args.Add(nameof(Produto.EstoqueIdeal), Produto.Estoque);
            Args.Add(nameof(Produto.EstoqueMinimo), Produto.EstoqueMinimo);
            Args.Add(nameof(Produto.MarcaId), Produto.MarcaId);
            Args.Add(nameof(Produto.PrecoVenda), Produto.PrecoVenda);
        }
    }
}