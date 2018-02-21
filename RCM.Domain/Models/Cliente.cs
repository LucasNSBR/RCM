using System.Collections.Generic;

namespace RCM.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}