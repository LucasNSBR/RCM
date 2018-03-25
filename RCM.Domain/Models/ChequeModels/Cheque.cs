using System;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Models.ChequeModels
{
    public class Cheque
    {
        public int Id { get; set; }
        public int BancoId { get; set; }
        public virtual Banco Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string NumeroCheque { get; set; }
        public string Observacao { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }
    }
}
