using RCM.Domain.Core.Models;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.ValueObjects;
using System;

namespace RCM.Domain.Models.DuplicataModels
{
    public class Duplicata : Entity<Duplicata>
    {
        public string NumeroDocumento { get; private set; }
        public string Observacao { get; private set; }

        public string NotaFiscalId { get; private set; }

        public DateTime DataEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }

        public Guid FornecedorId { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }

        public virtual Pagamento Pagamento { get; set; }


        protected Duplicata() { }

        public Duplicata(string numeroDocumento, DateTime dataEmissao, DateTime dataVencimento, Fornecedor fornecedor, decimal valor, string notaFiscalId, string observacao)
        {
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Fornecedor = fornecedor;
            Valor = valor;
            NotaFiscalId = notaFiscalId;
            Observacao = observacao ?? Observacao;

            Pagamento = new Pagamento();
        }

        public Duplicata(Guid id, string numeroDocumento, DateTime dataEmissao, DateTime dataVencimento, Fornecedor fornecedor, decimal valor, string notaFiscalId, string observacao)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Fornecedor = fornecedor;
            Valor = valor;
            NotaFiscalId = notaFiscalId;
            Observacao = observacao ?? Observacao;

            Pagamento = new Pagamento();
        }

        public bool Vencida()
        {
            return DataVencimento < DateTime.Now;
        }
        
        public void Pagar(Pagamento pagamento)
        {
            if (!Pagamento.IsEmpty)
                AddDomainError("O pagamento desse título já foi efetuado.");
            else
                Pagamento = new Pagamento(pagamento.DataPagamento, pagamento.ValorPago);
        }

        public void EstornarPagamento()
        {
            if (Pagamento.IsEmpty)
                AddDomainError("Esse título ainda não foi pago.");
            else
                Pagamento = new Pagamento();
        }
    }
}
