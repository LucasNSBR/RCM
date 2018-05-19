using RCM.Domain.Models.ProdutoModels;
using System;

namespace RCM.Domain.Models.VendaModels
{
    public class VendaProduto : IEquatable<VendaProduto>
    {
        public Guid VendaId { get; private set; }
        public virtual Venda Venda { get; private set; }
        public Guid ProdutoId { get; private set; }
        public virtual Produto Produto { get; private set; }

        //EF doesn't allow get only fields
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoFinal { get; private set; }

        public decimal Desconto { get; private set; }
        public decimal Acrescimo { get; private set; }
        public int Quantidade { get; private set; }


        protected VendaProduto() { }

        public VendaProduto(Venda venda, Produto produto)
        {
            Venda = venda;
            Produto = produto;

            PrecoVenda = produto.PrecoVenda;
        }

        public VendaProduto(Venda venda, Produto produto, decimal desconto, decimal acrescimo, int quantidade)
        {
            Venda = venda;
            Produto = produto;
            Desconto = desconto;
            Acrescimo = acrescimo;
            Quantidade = quantidade;

            PrecoVenda = produto.PrecoVenda;
            PrecoFinal = (PrecoVenda - Desconto + Acrescimo) * Quantidade;
        }

        public bool Equals(VendaProduto other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;
            if (other.Produto == null || other.Venda == null)
                return false;
            if (Produto.Id == other.Produto.Id && Venda.Id == other.Venda.Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (327 * Produto.Id.GetHashCode() + Venda.Id.GetHashCode());
        }
    }
}
