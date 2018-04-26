using RCM.Domain.Core.Models;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.MarcaModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.ProdutoModels
{
    public class Produto : Entity<Produto>
    {
        public string Nome { get; private set; }
        public string ReferenciaFabricante { get; private set; }
        public string ReferenciaOriginal { get; private set; }
        public string ReferenciaAuxiliar { get; private set; }

        private List<ProdutoAplicacao> _aplicacoes;
        public virtual IReadOnlyList<ProdutoAplicacao> Aplicacoes
        {
            get
            {
                return _aplicacoes;
            }
        }

        public int Estoque { get; private set; }
        public int EstoqueMinimo { get; private set; }
        public int EstoqueIdeal { get; private set; }

        public decimal PrecoVenda { get; private set; }

        private List<ProdutoFornecedor> _fornecedores;
        public virtual IReadOnlyList<ProdutoFornecedor> Fornecedores
        {
            get
            {
                return _fornecedores;
            }
        }

        public Guid MarcaId { get; private set; }
        public virtual Marca Marca { get; private set; }
        
        protected Produto() { }

        public Produto(string nome, int estoque, int estoqueMinimo, int estoqueIdeal, decimal precoVenda, Marca marca)
        {
            Nome = nome;
            Estoque = estoque;
            EstoqueMinimo = estoqueMinimo;
            EstoqueIdeal = estoqueIdeal;
            PrecoVenda = precoVenda;
            Marca = marca;

            _fornecedores = new List<ProdutoFornecedor>();
            _aplicacoes = new List<ProdutoAplicacao>();
        }

        public Produto(Guid id, string nome, int estoque, int estoqueMinimo, int estoqueIdeal, decimal precoVenda, Marca marca)
        {
            Id = id;
            Nome = nome;
            Estoque = estoque;
            EstoqueMinimo = estoqueMinimo;
            EstoqueIdeal = estoqueIdeal;
            PrecoVenda = precoVenda;
            Marca = marca;

            _fornecedores = new List<ProdutoFornecedor>();
            _aplicacoes = new List<ProdutoAplicacao>();
        }
        
        public void AdicionarReferencias(string referenciaFabricante, string referenciaOriginal, string referenciaAuxiliar)
        {
            ReferenciaAuxiliar = referenciaAuxiliar ?? ReferenciaAuxiliar;
            ReferenciaFabricante = referenciaFabricante ?? ReferenciaFabricante;
            ReferenciaOriginal = referenciaOriginal ?? ReferenciaOriginal;
        }

        public void AdicionarFornecedor(Fornecedor fornecedor, decimal precoCusto, ProdutoDisponibilidadeEnum disponibilidade)
        {
            _fornecedores = _fornecedores ?? new List<ProdutoFornecedor>();

            ProdutoFornecedor produtoFornecedor = new ProdutoFornecedor(this, fornecedor, precoCusto, disponibilidade);

            if (!_fornecedores.Contains(produtoFornecedor))
                _fornecedores.Add(produtoFornecedor);
            else
                AddDomainError("O fornecedor já está relacionado ao produto.");
        }

        public void RemoverFornecedor(Fornecedor fornecedor)
        {
            ProdutoFornecedor produtoFornecedor = new ProdutoFornecedor(this, fornecedor);

            if (_fornecedores.Contains(produtoFornecedor))
                _fornecedores.Remove(produtoFornecedor);
            else
                AddDomainError("O produto não está relacionado a esse fornecedor.");
        }

        public void AdicionarAplicacao(Aplicacao aplicacao)
        {
            _aplicacoes = _aplicacoes ?? new List<ProdutoAplicacao>();
            
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao(this, aplicacao);

            if (!_aplicacoes.Contains(produtoAplicacao))
                _aplicacoes.Add(produtoAplicacao);
            else
                AddDomainError("A aplicação já existe no produto.");
        }

        public void RemoverAplicacao(Aplicacao aplicacao)
        {
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao(this, aplicacao);

            if (_aplicacoes.Contains(produtoAplicacao))
                _aplicacoes.Remove(produtoAplicacao);
            else
                AddDomainError("O produto não contém a aplicação.");
        }

        public void ReporEstoque(int estoque)
        {
            Estoque += estoque;
        }

    }
}
