﻿using RCM.Domain.Core.Models;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.FornecedorModels
{
    public class Fornecedor : Entity<Fornecedor>
    {
        public string Nome { get; private set; }
        public FornecedorTipoEnum Tipo { get; private set; }
        public string Descricao { get; private set; }

        public Contato Contato { get; private set; }
        public Endereco Endereco { get; private set; }
        public Documento Documento { get; private set; }

        private List<Duplicata> _duplicatas;
        public virtual IReadOnlyList<Duplicata> Duplicatas
        {
            get
            {
                return _duplicatas;
            }
        }

        private List<ProdutoFornecedor> _produtos;
        public virtual IReadOnlyList<ProdutoFornecedor> Produtos
        {
            get
            {
                return _produtos;
            }
        }

        protected Fornecedor() { }

        public Fornecedor(Guid id, string nome, FornecedorTipoEnum tipo, Documento documento, Contato contato, Endereco endereco, string observacao = null)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Documento = documento;
            Contato = contato;
            Endereco = endereco;
            Descricao = observacao;

            _duplicatas = new List<Duplicata>();
            _produtos = new List<ProdutoFornecedor>();
        }

        public Fornecedor(string nome, FornecedorTipoEnum tipo, Documento documento, Contato contato, Endereco endereco, string observacao = null)
        {
            Nome = nome;
            Tipo = tipo;
            Documento = documento;
            Contato = contato;
            Endereco = endereco;
            Descricao = observacao;

            _duplicatas = new List<Duplicata>();
            _produtos = new List<ProdutoFornecedor>();
        }
    }
}