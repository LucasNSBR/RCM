using RCM.Domain.Core.Models;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.NotaFiscalModels
{
    public class NotaFiscal : Entity
    {
        public string NumeroDocumento { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataChegada { get; private set; }
        public decimal Valor { get; private set; }

        private List<Duplicata> _duplicatas; 
        public virtual IReadOnlyList<Duplicata> Duplicatas
        {
            get
            {
                return _duplicatas;
            }
        }

        private List<Produto> _produtos;
        public virtual IReadOnlyList<Produto> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        protected NotaFiscal() { }

        public NotaFiscal(string numeroDocumento, DateTime dataEmissao, DateTime dataChegada, decimal valor, List<Produto> produtos)
        {
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            DataChegada = dataChegada;
            Valor = valor;

            _duplicatas = new List<Duplicata>();
            _produtos = new List<Produto>();
        }
    }
}