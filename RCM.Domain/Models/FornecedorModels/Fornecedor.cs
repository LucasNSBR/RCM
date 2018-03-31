using RCM.Domain.Core.Models;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Models.ProdutoModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.FornecedorModels
{
    public class Fornecedor : Entity<Fornecedor>
    {
        public string Nome { get; private set; }
        public string Observacao { get; private set; }

        private List<Duplicata> _duplicatas;
        public virtual IReadOnlyList<Duplicata> Duplicatas
        {
            get
            {
                return _duplicatas;
            }
        }

        private List<NotaFiscal> _notasFiscais;
        public virtual IReadOnlyList<NotaFiscal> NotasFiscais
        {
            get
            {
                return _notasFiscais;
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

        protected Fornecedor() { }

        public Fornecedor(string nome)
        {
            Nome = nome;

            _duplicatas = new List<Duplicata>();
            _notasFiscais = new List<NotaFiscal>();
            _produtos = new List<Produto>();
        }
    }
}