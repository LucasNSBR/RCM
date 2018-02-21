using System.Collections.Generic;

namespace RCM.Application.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<ContatoViewModel> Contatos { get; set; }
        public ICollection<EnderecoViewModel> Enderecos { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}