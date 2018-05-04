using System;

namespace RCM.Application.ViewModels
{
    public class VendaProdutoViewModel
    {
        public Guid VendaId { get; set; }
        public VendaViewModel Venda { get; set; }
        public Guid ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }

        public decimal PrecoVenda
        {
            get
            {
                return Produto.PrecoVenda;
            }
        }

        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }

        public decimal PrecoFinal
        {
            get
            {
                return PrecoVenda - Desconto + Acrescimo;
            }
        }
    }
}
