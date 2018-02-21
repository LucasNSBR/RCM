namespace RCM.Domain.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}