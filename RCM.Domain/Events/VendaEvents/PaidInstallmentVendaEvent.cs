using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class PaidInstallmentVendaEvent : VendaEvent
    {
        public Parcela Parcela { get; private set; }

        public PaidInstallmentVendaEvent(Venda venda, Parcela parcela) : base(venda)
        {
            Parcela = parcela;
        }

        public override void Normalize()
        {
            Args.Add($"Parcela{nameof(Parcela.Numero)}", Parcela.Numero);
            Args.Add($"Parcela{nameof(Parcela.Valor)}", Parcela.Valor);
            Args.Add($"Parcela{nameof(Parcela.DataVencimento)}", Parcela.DataVencimento);
            Args.Add($"Parcela{nameof(Parcela.DataPagamento)}", Parcela.DataPagamento);
        }
    }
}
