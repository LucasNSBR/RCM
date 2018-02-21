using System.Collections.Generic;

namespace RCM.Application.ViewModels
{
    public class EstadoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<CidadeViewModel> Cidades { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}