using System;

namespace RCM.Application.ViewModels
{
    public class ChequeViewModel
    {
        public int Id { get; set; }
        public int BancoId { get; set; }
        public BancoViewModel Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string NumeroCheque { get; set; }
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return NumeroCheque;
        }
    }
}
