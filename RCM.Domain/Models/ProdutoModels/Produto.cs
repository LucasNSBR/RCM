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

        private List<Fornecedor> _fornecedores;
        public virtual IReadOnlyList<Fornecedor> Fornecedores
        {
            get
            {
                return _fornecedores;
            }
        }

        public Guid MarcaId { get; private set; }
        public virtual Marca Marca { get; private set; }

        protected Produto() { }

        public Produto(Guid id, string nome, int estoque, decimal precoVenda, Marca marca)
        {
            Id = id;
            Nome = nome;
            Estoque = estoque;
            PrecoVenda = precoVenda;
            Marca = marca;
            
            _fornecedores = new List<Fornecedor>();
            _aplicacoes = new List<ProdutoAplicacao>();
        }

        public Produto(string nome, int estoque, decimal precoVenda, Marca marca)
        {
            Nome = nome;
            Estoque = estoque;
            PrecoVenda = precoVenda;
            Marca = marca;

            _fornecedores = new List<Fornecedor>();
            _aplicacoes = new List<ProdutoAplicacao>();
        }

        public void ReporEstoque(int estoque)
        {
            Estoque += estoque;
        }

        public void AdicionarAplicacao(Aplicacao aplicacao)
        {
            if (_aplicacoes == null)
                _aplicacoes = new List<ProdutoAplicacao>();
            
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
        }
    }
}
