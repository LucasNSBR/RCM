namespace RCM.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set;  }
        public CidadeViewModel Cidade { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro}";
        }
    }
}