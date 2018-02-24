using System;
using System.Collections.Generic;

namespace RCM.Application.ViewModels
{
    public class NotaFiscalViewModel
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public virtual ICollection<DuplicataViewModel> Duplicatas { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataChegada { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }
}