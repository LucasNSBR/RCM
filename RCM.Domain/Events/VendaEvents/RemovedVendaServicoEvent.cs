using RCM.Domain.Models.ServicoModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class RemovedVendaServicoEvent : VendaEvent
    {
        public Servico Servico { get; private set; }

        public RemovedVendaServicoEvent(Venda venda, Servico servico) : base(venda)
        {
            Servico = servico;
        }

        public override void Normalize()
        {
            Args.Add("ServicoId", Servico.Id);
        }
    }
}
