using RCM.Domain.Core.Models;
using RCM.Domain.Models.FornecedorModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.ProdutoModels
{
    public class Produto : Entity<Produto>
    {
        public string Nome { get; private set; }

        private List<ProdutoAplicacao> _aplicacoes;
        public IReadOnlyList<ProdutoAplicacao> Aplicacoes
        {
            get
            {
                return _aplicacoes;
            }
        }

        public int Quantidade { get; private set; }
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

        public Produto(Guid id, string nome, int quantidade, decimal precoVenda, Marca marca)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            PrecoVenda = precoVenda;
            Marca = marca;
            
            _fornecedores = new List<Fornecedor>();
            _aplicacoes = new List<ProdutoAplicacao>();
        }

        public Produto(string nome, int quantidade, decimal precoVenda, Marca marca)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoVenda = precoVenda;
            Marca = marca;

            _fornecedores = new List<Fornecedor>();
            _aplicacoes = new List<ProdutoAplicacao>();
        }

        public void ReporEstoque(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}
