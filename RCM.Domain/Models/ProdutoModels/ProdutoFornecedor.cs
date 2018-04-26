using RCM.Domain.Models.FornecedorModels;
using System;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoFornecedor : IEquatable<ProdutoFornecedor>
    {
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public Guid FornecedorId { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public ProdutoDisponibilidadeEnum Disponibilidade { get; private set; }

        protected ProdutoFornecedor() { }

        public ProdutoFornecedor(Produto produto, Fornecedor fornecedor)
        {
            Produto = produto;
            Fornecedor = fornecedor;
        }

        public ProdutoFornecedor(Produto produto, Fornecedor fornecedor, decimal precoCusto, ProdutoDisponibilidadeEnum disponibilidade)
        {
            Produto = produto;
            Fornecedor = fornecedor;
            Disponibilidade = disponibilidade;
            PrecoCusto = precoCusto;
        }

        public bool Equals(ProdutoFornecedor other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;
            if (other.ProdutoId == null || other.FornecedorId == null)
                return false;
            if (Produto.Id == other.Produto.Id && Fornecedor.Id == other.Fornecedor.Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (327 * Produto.Id.GetHashCode() + Fornecedor.Id.GetHashCode());
        }
    }
}
