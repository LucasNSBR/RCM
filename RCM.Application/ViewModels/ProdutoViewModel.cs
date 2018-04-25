using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O campo nome deve ter entre 5 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Referência do Fabricante")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "O campo referência do fabricante deve ter entre até 25 caracteres.")]
        public string ReferenciaFabricante { get; set; }

        [Display(Name = "Referência Original")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "O campo referência original deve até 25 caracteres.")]
        public string ReferenciaOriginal { get; set; }

        [Display(Name = "Referência Auxiliar")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "O campo referência auxiliar deve até 50 caracteres.")]
        public string ReferenciaAuxiliar { get; set; }

        [Display(Name = "Estoque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo estoque é requerido.")]
        [Range(0, 9999, ErrorMessage = "A quantidade no estoque deve estar em um formato válido.")]
        public int Estoque { get; set; }

        [Display(Name = "Estoque Mínimo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo estoque mínimo é requerido.")]
        [Range(0, 9999, ErrorMessage = "A quantidade mínima no estoque deve estar em um formato válido.")]
        public int EstoqueMinimo { get; set; }

        [Display(Name = "Estoque Ideal")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo estoque ideal é requerido.")]
        [Range(0, 9999, ErrorMessage = "A quantidade ideal no estoque deve estar em um formato válido.")]
        public int EstoqueIdeal { get; set; }

        [Display(Name = "Preço de Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo preço de venda é requerido.")]
        public decimal PrecoVenda { get; set; }

        //[Display(Name = "Fornecedores")]
        //public List<FornecedorViewModel> Fornecedores { get; set; }

        [Display(Name = "Aplicações")]
        public List<AplicacaoViewModel> Aplicacoes { get; set; }
        
        [Display(Name = "Id da Marca")]
        public Guid MarcaId { get; set; }

        [Display(Name = "Marcas")]
        public MarcaViewModel Marca { get; set; }

        public ProdutoViewModel()
        {
            Aplicacoes = Aplicacoes ?? new List<AplicacaoViewModel>();
        }
    }
}
