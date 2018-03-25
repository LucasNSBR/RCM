using RCM.Domain.Models.EstadoModels;

namespace RCM.Domain.Models.CidadeModels
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}