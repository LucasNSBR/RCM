namespace RCM.Application.ViewModels
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EstadoViewModel Estado { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}