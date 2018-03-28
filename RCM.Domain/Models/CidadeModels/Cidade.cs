using RCM.Domain.Models.EstadoModels;

namespace RCM.Domain.Models.CidadeModels
{
    public class Cidade
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int EstadoId { get; private set; }
        public virtual Estado Estado { get; private set; }

        private Cidade() { }

        public Cidade(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
        }
    }
}