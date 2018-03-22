namespace RCM.Domain.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Observacao { get; set; }
    }
}