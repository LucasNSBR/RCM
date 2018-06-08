using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class CheckedOutVendaEvent : VendaEvent
    {
        public CheckedOutVendaEvent(Venda venda) : base(venda)
        {
        }

        public override void Normalize()
        {
            Args.Add(nameof(Venda.DataVenda), Venda.DataVenda);
            Args.Add(nameof(Venda.ClienteId), Venda.ClienteId);
            Args.Add(nameof(Venda.QuantidadeItens), Venda.QuantidadeItens);
            Args.Add(nameof(Venda.Status), Venda.Status);
            Args.Add(nameof(Venda.TotalVenda), Venda.TotalVenda);
            Args.Add(nameof(Venda.CondicaoPagamento.ValorEntrada), Venda.CondicaoPagamento.ValorEntrada);
            Args.Add(nameof(Venda.CondicaoPagamento.QuantidadeParcelas), Venda.CondicaoPagamento.QuantidadeParcelas);
            Args.Add(nameof(Venda.CondicaoPagamento.IntervaloVencimento), Venda.CondicaoPagamento.IntervaloVencimento);
        }
    }
}
