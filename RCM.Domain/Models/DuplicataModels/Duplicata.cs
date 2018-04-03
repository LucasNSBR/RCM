using RCM.Domain.Core.Models;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.NotaFiscalModels;
using System;

namespace RCM.Domain.Models.DuplicataModels
{
    public class Duplicata : Entity<Duplicata>
    {
        public string NumeroDocumento { get; private set; }
        public string Observacao { get; private set; }
        public Guid? NotaFiscalId { get; private set; }
        public virtual NotaFiscal NotaFiscal { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public Guid FornecedorId { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Pagamento Pagamento { get; set; }

        protected Duplicata() { }

        public Duplicata(string numeroDocumento, DateTime dataEmissao, DateTime dataVencimento, Guid fornecedorId, decimal valor, string observacao = null)
        {
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            FornecedorId = fornecedorId;
            Valor = valor;
            Observacao = observacao ?? Observacao;

            Pagamento = new Pagamento();
        }

        public Duplicata(Guid id, string numeroDocumento, DateTime dataEmissao, DateTime dataVencimento, Guid fornecedorId, decimal valor, string observacao = null)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            FornecedorId = fornecedorId;
            Valor = valor;
            Observacao = observacao ?? Observacao;

            Pagamento = new Pagamento();
        }

        public bool Vencida()
        {
            return DataVencimento < DateTime.Now;
        }

        public void VincularNotaFiscal(Guid notaFiscalId)
        {
            NotaFiscalId = notaFiscalId;
        }

        public void Pagar(Pagamento pagamento)
        {
            Pagamento = new Pagamento(pagamento.DataPagamento, pagamento.ValorPago) ?? throw new ArgumentNullException("Pagamento");
        }

        public void EstornarPagamento()
        {
            Pagamento = new Pagamento();
        }
    }
}
