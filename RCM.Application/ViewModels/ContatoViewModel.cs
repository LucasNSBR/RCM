namespace RCM.Application.ViewModels
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}