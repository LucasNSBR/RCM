using System;
using System.Collections.Generic;

namespace RCM.Domain.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataChegada { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Duplicata> Duplicatas { get; set; }
        public virtual ICollection<NotaFiscal> NotasFiscais { get; set; }

        public NotaFiscal()
        {
            Duplicatas = new List<Duplicata>();
            NotasFiscais = new List<NotaFiscal>();
        }
    }
}