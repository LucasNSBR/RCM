using System.Collections.Generic;

namespace RCM.Domain.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}