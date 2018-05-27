using Newtonsoft.Json;
using RCM.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.VendaModels
{
    public class CondicaoPagamento : ValueObject
    {
        public TipoVenda TipoVenda { get; private set; }

        public decimal TotalVenda { get; private set; }
        public int QuantidadeParcelas { get; private set; }
        public int IntervaloVencimento { get; private set;  }
        public decimal ValorEntrada { get; private set; }

        [JsonIgnore]
        public decimal ValorPago
        {
            get
            {
                if (_parcelas == null)
                    return ValorEntrada;

                return ValorEntrada + _parcelas
                    .Where(p => p.Paga)
                    .Sum(p => p.Valor);
            }
        }
        
        [JsonIgnore]
        public decimal ValorRestante
        {
            get
            {
                return TotalVenda - ValorPago;
            }
        }

        private List<Parcela> _parcelas;
        public IReadOnlyList<Parcela> Parcelas
        {
            get
            {
                if(_parcelas == null)
                    _parcelas = new List<Parcela>();

                return _parcelas;
            }
        }

        public CondicaoPagamento(TipoVenda tipoVenda, decimal totalVenda, decimal valorEntrada)
        {
            TipoVenda = tipoVenda;
            TotalVenda = totalVenda;
            ValorEntrada = valorEntrada;
        }

        [JsonConstructor]
        public CondicaoPagamento(TipoVenda tipoVenda, decimal totalVenda, int quantidadeParcelas, int intervaloVencimento, decimal valorEntrada, List<Parcela> parcelas)
        {
            TipoVenda = tipoVenda;
            TotalVenda = totalVenda;
            QuantidadeParcelas = quantidadeParcelas;
            IntervaloVencimento = intervaloVencimento;
            ValorEntrada = valorEntrada;
            _parcelas = parcelas;
        }
    }
}
