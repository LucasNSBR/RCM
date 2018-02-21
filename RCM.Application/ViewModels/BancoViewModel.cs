namespace RCM.Application.ViewModels
{
    public class BancoViewModel
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
