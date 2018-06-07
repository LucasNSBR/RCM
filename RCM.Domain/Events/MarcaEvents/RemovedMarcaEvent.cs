using RCM.Domain.Models.MarcaModels;

namespace RCM.Domain.Events.MarcaEvents
{
    public class RemovedMarcaEvent : MarcaEvent
    {
        public RemovedMarcaEvent(Marca marca) : base(marca)
        {
        }

        public override void Normalize()
        {
            Args.Add(nameof(Marca.Id), Marca.Id);
        }
    }
}
