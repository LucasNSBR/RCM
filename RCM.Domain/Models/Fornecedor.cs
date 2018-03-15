using System.Collections.Generic;

namespace RCM.Domain.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //public string Observacao { get; set; }

        public virtual ICollection<Duplicata> Duplicatas { get; set; }
        public virtual ICollection<NotaFiscal> NotasFiscais { get; set; }

        public Fornecedor()
        {
            Duplicatas = new List<Duplicata>();
            NotasFiscais = new List<NotaFiscal>();
        }
    }
}