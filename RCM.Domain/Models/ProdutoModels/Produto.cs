using RCM.Domain.Models.FornecedorModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.ProdutoModels
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Aplicacao { get; set; }
        public string Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
