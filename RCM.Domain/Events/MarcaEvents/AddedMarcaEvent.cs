using RCM.Domain.Models.MarcaModels;

namespace RCM.Domain.Events.MarcaEvents
{
    public class AddedMarcaEvent : MarcaEvent
    {
        public AddedMarcaEvent(Marca marca) : base(marca)
        {
        }
    }
}
