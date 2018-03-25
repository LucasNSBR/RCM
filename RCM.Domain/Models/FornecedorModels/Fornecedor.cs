using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.NotaFiscalModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.FornecedorModels
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public virtual ICollection<Duplicata> Duplicatas { get; set; }
        public virtual ICollection<NotaFiscal> NotasFiscais { get; set; }

        public Fornecedor()
        {
            Duplicatas = new List<Duplicata>();
            NotasFiscais = new List<NotaFiscal>();
        }
    }
}