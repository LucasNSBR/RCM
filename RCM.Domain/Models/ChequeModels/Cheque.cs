using System;
using RCM.Domain.Core.Models;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Models.ChequeModels
{
    public class Cheque : Entity<Cheque>
    {
        public Guid BancoId { get; private set; }
        public virtual Banco Banco { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public string NumeroCheque { get; private set; }
        public string Observacao { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime? DataPagamento { get; private set; }
        public decimal Valor { get; private set; }

        protected Cheque() { }
        
        public Cheque(Banco banco, string agencia, string conta, string numeroCheque, Cliente cliente, DateTime dataEmissao, DateTime dataVencimento, decimal valor)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            NumeroCheque = numeroCheque;
            Cliente = cliente;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Valor = valor;
        }
    }
}
