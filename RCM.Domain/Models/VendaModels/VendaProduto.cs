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

        public decimal PrecoVenda
        {
            get
            {
                return Produto.PrecoVenda;
            }
        }

        public decimal Desconto { get; private set; }
        public decimal Acrescimo { get; private set; }
        
        public decimal PrecoFinal
        {
            get
            {
                return PrecoVenda - Desconto + Acrescimo; 
            }
        }

        public VendaProduto(Venda venda, Produto produto)
        {
            Venda = venda;
            Produto = produto;
        }

        public VendaProduto(Venda venda, Produto produto, decimal desconto, decimal acrescimo)
        {
            Venda = venda;
            Produto = produto;
            Desconto = desconto;
            Acrescimo = acrescimo;
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
