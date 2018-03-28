using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Models
{
    public class Contato
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public string Observacao { get; private set; }

        private Contato() { }

        public Contato(string nome, Cliente cliente)
        {
            Nome = nome;
            Cliente = cliente;
        }
    }
}