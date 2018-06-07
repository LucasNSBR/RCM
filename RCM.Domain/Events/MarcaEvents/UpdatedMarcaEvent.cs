using RCM.Domain.Models.MarcaModels;

namespace RCM.Domain.Events.MarcaEvents
{
    public class UpdatedMarcaEvent : MarcaEvent
    {
        public UpdatedMarcaEvent(Marca marca) : base(marca)
        {
        }
    }
}
