using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.NotaFiscalModels;
using System;

namespace RCM.Domain.Models.DuplicataModels
{
    public class Duplicata
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Observacao { get; set; }
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public decimal Valor { get; set; }
    }
}
