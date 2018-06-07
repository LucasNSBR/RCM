using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.ViewModels
{
    public class ClienteIndexViewModel
    {
        public PagedList<ClienteViewModel> Clientes { get; set; }

        public string Tipo { get; set; }
        public string Pontuacao { get; set; }
        public string Nome { get; set; }
        public string CadastroNacional { get; set; }
        public string CadastroEstadual { get; set; }
    }
}
