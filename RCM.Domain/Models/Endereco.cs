namespace RCM.Domain.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set;  }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro}";
        }
    }
}