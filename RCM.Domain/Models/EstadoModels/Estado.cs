using RCM.Domain.Models.CidadeModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.EstadoModels
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}