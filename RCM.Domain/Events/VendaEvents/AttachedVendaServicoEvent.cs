using RCM.Domain.Models.ServicoModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class AttachedVendaServicoEvent : VendaEvent
    {
        public Servico Servico { get; private set; }

        public AttachedVendaServicoEvent(Venda venda, Servico servico) : base(venda)
        {
            Servico = servico;
        }

        public override void Normalize()
        {
            Args.Add("ServicoId", Servico.Id);
            Args.Add(nameof(Servico.Detalhes), Servico.Detalhes);
            Args.Add(nameof(Servico.PrecoServico), Servico.PrecoServico);
        }
    }
}
