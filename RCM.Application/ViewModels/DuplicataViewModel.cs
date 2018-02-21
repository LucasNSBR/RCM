using System;

namespace RCM.Application.ViewModels
{
    public class DuplicataViewModel
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }
}
