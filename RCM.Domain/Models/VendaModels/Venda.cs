using Newtonsoft.Json;
using RCM.Domain.Core.Models;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Domain.Models.VendaModels
{
    public class Venda : Entity<Venda>
    {
        public DateTime DataVenda { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public string Detalhes { get; private set; }

        private List<VendaProduto> _produtos;
        public virtual IReadOnlyList<VendaProduto> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        public int QuantidadeProdutos { get; private set; }
        public decimal TotalVenda { get; private set; }

        public VendaStatusEnum Status { get; private set; }

        private string _condicaoPagamento; 
        public CondicaoPagamento CondicaoPagamento
        {
            get
            {
                if (_condicaoPagamento == null)
                    return null;

                return JsonConvert.DeserializeObject<CondicaoPagamento>(_condicaoPagamento);
            }
            private set
            {
                _condicaoPagamento = JsonConvert.SerializeObject(value);
            }
        }


        protected Venda() { }

        public Venda(DateTime dataVenda, string detalhes, Cliente cliente)
        {
            DataVenda = dataVenda;
            Detalhes = detalhes;
            Cliente = cliente;

            Status = VendaStatusEnum.Aberta;
            _produtos = new List<VendaProduto>();
        }

        public Venda(Guid id, DateTime dataVenda, string detalhes, Cliente cliente)
        {
            Id = id;
            DataVenda = dataVenda;
            Detalhes = detalhes;
            Cliente = cliente;

            Status = VendaStatusEnum.Aberta;
            _produtos = new List<VendaProduto>();
        }

        public void AdicionarProduto(Produto produto, decimal desconto, decimal acrescimo, int quantidade)
        {
            if (Status != VendaStatusEnum.Aberta)
            {
                AddDomainError("A venda já foi finalizada. Não é possível adicionar mais itens agora.");
                return;
            }

            if (produto.Estoque < quantidade)
            {
                AddDomainError("O estoque não tem essa quantidade disponível.");
                return;
            }

            VendaProduto vendaProduto = new VendaProduto(this, produto, desconto, acrescimo, quantidade);

            if (!_produtos.Contains(vendaProduto))
            {
                if (!produto.DeduzirEstoque(quantidade))
                {
                    AddDomainError("Erro ao deduzir do estoque.");
                    return;
                }

                _produtos.Add(vendaProduto);
                QuantidadeProdutos += vendaProduto.Quantidade;
                TotalVenda += vendaProduto.PrecoFinal;
            }
            else
                AddDomainError("O produto já foi adicionado à venda.");
        }

        public void RemoverProduto(Produto produto)
        {
            if (Status != VendaStatusEnum.Aberta)
            {
                AddDomainError("A venda já foi finalizada. Não foi possível remover esse item.");
                return;
            }

            VendaProduto vendaProduto = _produtos.Find(c => c.Equals(new VendaProduto(this, produto)));

            if (_produtos.Contains(vendaProduto))
            {
                _produtos.Remove(vendaProduto);

                QuantidadeProdutos -= vendaProduto.Quantidade;
                TotalVenda -= vendaProduto.PrecoFinal;
                produto.ReporEstoque(vendaProduto.Quantidade);
            }
            else
                AddDomainError("O produto ainda não foi adicionado à venda.");
        }

        public Venda Finalizar(TipoVenda tipoVenda, int quantidadeParcelas, int intervaloVencimento, decimal valorEntrada)
        {
            if (!_produtos.Any())
                AddDomainError("Não é possível finalizar a venda sem nenhum item.");

            if (TotalVenda <= 0)
                AddDomainError("Não é possível finalizar uma venda com valor total zerado ou negativo.");

            if (Status == VendaStatusEnum.Fechada)
                AddDomainError("A venda já foi finalizada.");

            if (tipoVenda == TipoVenda.AVista)
                CondicaoPagamento = ConfigurarVendaVista(TotalVenda);
            else
                CondicaoPagamento = ConfigurarVendaPrazo(TotalVenda, quantidadeParcelas, intervaloVencimento, valorEntrada);

            Status = VendaStatusEnum.Fechada;

            return this;
        }

        private CondicaoPagamento ConfigurarVendaVista(decimal totalVenda)
        {
            //Setup a payment object without Installments and initial payment value (Entrada) = total sell value
            return new CondicaoPagamento(TipoVenda.AVista, totalVenda, valorEntrada: totalVenda);
        }
        
        private CondicaoPagamento ConfigurarVendaPrazo(decimal totalVenda, int quantidadeParcelas, int intervaloVencimento, decimal entrada)
        {
            decimal valorParcela = (totalVenda - entrada) / quantidadeParcelas;
            List<Parcela> parcelas = new List<Parcela>();

            //Setup Installments based on Index and Interval
            for (int i = 1; i <= quantidadeParcelas; i++)
            {
                Parcela parcela = new Parcela(i, DateTime.Now.AddDays(intervaloVencimento * i), valorParcela);
                parcelas.Add(parcela);
            };

            return new CondicaoPagamento(TipoVenda.APrazo, totalVenda, quantidadeParcelas, intervaloVencimento, entrada, parcelas);
        }

        public void PagarParcela(int parcelaId)
        {
            var index = parcelaId - 1;

            List<Parcela> parcelas = CondicaoPagamento.Parcelas.ToList();
            Parcela oldParcela = parcelas[index];

            parcelas[index] = new Parcela(parcelaId, oldParcela.DataVencimento, oldParcela.Valor, DateTime.Now);

            //Trigger Parcelamento setter in order to serialize new value
            CondicaoPagamento = new CondicaoPagamento(TipoVenda.APrazo, TotalVenda, CondicaoPagamento.QuantidadeParcelas, CondicaoPagamento.IntervaloVencimento, CondicaoPagamento.ValorEntrada, parcelas);
        }
    }
}
