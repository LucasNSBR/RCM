namespace RCM.Domain.Models
{
    public class Banco
    {
        public int Id { get; set; }
        public int CodigoCompensacao { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}