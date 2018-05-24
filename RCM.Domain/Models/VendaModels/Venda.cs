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

        internal string _parcelas; 
        public List<Parcela> Parcelas
        {
            get
            {
                if (_parcelas == null)
                    return null;

                return JsonConvert.DeserializeObject<List<Parcela>>(_parcelas);
            }
            private set
            {
                _parcelas = JsonConvert.SerializeObject(value);
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

        public Venda Finalizar()
        {
            if (!_produtos.Any())
            {
                AddDomainError("Não é possível finalizar a venda sem nenhum item.");
                return null;
            }

            if (Status == VendaStatusEnum.Aberta)
                Status = VendaStatusEnum.Fechada;
            else
                AddDomainError("A venda já foi finalizada.");

            return this;
        }

        public void AdicionarParcelas(List<Parcela> parcelas)
        {
            Parcelas = parcelas;
        }
    }
}
